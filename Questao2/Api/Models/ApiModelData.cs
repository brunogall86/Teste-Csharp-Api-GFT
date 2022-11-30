using System.Text.Json.Serialization;
namespace Questao2.Api.Models
{
    public class ApiModelData
    {
        [JsonPropertyName("competition")]
        public string competition { get; set; }

        [JsonPropertyName("year")]
        public int year { get; set; }

        [JsonPropertyName("round")]
        public string round { get; set; }

        [JsonPropertyName("team1")]
        public string team1 { get; set; }

        [JsonPropertyName("team2")]
        public string team2 { get; set; }

        [JsonPropertyName("team1goals")]
        public string team1goals { get; set; }

        [JsonPropertyName("team2goals")]
        public string team2goals { get; set; }
    }

}
