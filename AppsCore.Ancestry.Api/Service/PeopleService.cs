using System;
using System.Collections.Generic;
using System.Linq;
using AppsCore.Ancestry.Api.Config;
using AppsCore.Ancestry.Api.Constants;
using AppsCore.Ancestry.Api.DataReadClient;
using AppsCore.Ancestry.Api.Model;

namespace AppsCore.Ancestry.Api.Service
{
    public class PeopleService:IPeopleService
    {
        private readonly IAppConfiguration _configuration;
        private readonly IDataReadClient<AncestralData> _dataReadClient;
        public PeopleService(IAppConfiguration configuration, IDataReadClient<AncestralData> dataReadClient)
        {
            _configuration = configuration;
            _dataReadClient = dataReadClient;
        }
        public List<PeopleSearchResponse> SearchPeople(PeopleSearchRequest request)
        {
            var data = _dataReadClient.ReadJsonData(_configuration.DataFile);
            var result = new List<PeopleSearchResponse>();
           
            if (request.Gender == null) 
            {
                foreach (var ancestralData in data)
                {
                    var  people = ancestralData.People.Where(n => n.Name.ToLower().Contains(request.Keyword.ToLower()));

                    result.AddRange(from person in people
                        let birthPlace = ancestralData.Places.FirstOrDefault(s => s.Id == person.PlaceId)?.Name
                        select new PeopleSearchResponse(person, birthPlace));
                }
            }
            else
            {
                var gender = request.Gender == Gender.Female ? "F" : "M";

                foreach (var ancestralData in data)
                {
                    var people = ancestralData.People.Where(n =>
                        n.Name.ToLower().Contains(request.Keyword.ToLower()) && string.Equals(n.Gender, gender, StringComparison.CurrentCultureIgnoreCase));

                    result.AddRange(from person in people
                        let birthPlace = ancestralData.Places.FirstOrDefault(s => s.Id == person.PlaceId)?.Name
                        select new PeopleSearchResponse(person, birthPlace));
                }
            }

            return result;
        }
    }
}
