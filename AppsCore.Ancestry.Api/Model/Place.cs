using Newtonsoft.Json;

namespace AppsCore.Ancestry.Api.Model
{
    public class Place
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
