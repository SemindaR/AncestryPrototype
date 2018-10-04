using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class _Default : Page
{
    private const string URL = "http://localhost:36769/api/search";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected async void Button1_Click(object sender, EventArgs e)
    {
        var urlParameters = $"?keyword={searchName.Text.Trim()}";
        List<string> selectedValues = genderSelection.Items.Cast<ListItem>()
            .Where(li => li.Selected)
            .Select(li => li.Value)
            .ToList();
        if (selectedValues.Count == 1)
        {
            urlParameters = urlParameters + $"&gender={selectedValues[0]}";
        }

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(URL);
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        // List data response.
        HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<PersonData>>(responseBody);
            displayGrid.DataSource = data.Take(10);
            displayGrid.DataBind();
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
    }
}

public class PersonData
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public string BirthPlace { get; set; }
}