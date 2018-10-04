using System;
using AppsCore.Ancestry.Api.Constants;

namespace AppsCore.Ancestry.Api.Model
{
    public class PeopleSearchResponse
    {
        public PeopleSearchResponse(Person person, string birthPlace)
        {
            Name = person.Name;
            Gender = person.Gender=="M"?Gender.Male:Gender.Female;
            BirthPlace = birthPlace;
        }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string BirthPlace { get; set; }
    }
}
