using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Questao2.Api.Models
{
    public class ApiRootModel
    { 
        [JsonPropertyName("page")]
        public int page { get; set; }

        [JsonPropertyName("per_page")]
        public int per_page { get; set; }

        [JsonPropertyName("total")]
        public int total { get; set; }

        [JsonPropertyName("total_pages")]
        public int total_pages { get; set; }

        [JsonPropertyName("data")]
        public List<ApiModelData> data { get; set; }
    }

}
