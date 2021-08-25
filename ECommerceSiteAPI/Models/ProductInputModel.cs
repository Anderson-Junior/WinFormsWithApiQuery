using Newtonsoft.Json;

namespace ECommerceSiteAPI.Models
{
    public class ProductInputModel
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }
    }
}
