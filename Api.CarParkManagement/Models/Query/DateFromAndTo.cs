using Newtonsoft.Json;

namespace Api.CarParkManagement.Models.Query
{
    public class DateFromAndTo
    {
        [JsonProperty("dateFrom")]
        public DateTime DateFrom { get; set; }

        [JsonProperty("dateTo")]
        public DateTime DateTo { get; set; }
    }
}
