using Newtonsoft.Json;

namespace AppsCore.Ancestry.Api.Model
{
    public class Person
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("father_id")]
        public string FatherId { get; set; }

        [JsonProperty("mother_id")]
        public string MotherId { get; set; }

        [JsonProperty("place_id")]
        public long PlaceId { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }
    }
}
