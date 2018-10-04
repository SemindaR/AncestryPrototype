using System.Collections.Generic;
using System.Runtime.Serialization;
using AppsCore.Ancestry.Api.Constants;

namespace AppsCore.Ancestry.Api.Model
{
    [DataContract]
    public class PeopleSearchRequest
    {
        [DataMember]
        public string Keyword { get; set; }

        [DataMember]
        public Gender? Gender { get; set; }
    }
}
