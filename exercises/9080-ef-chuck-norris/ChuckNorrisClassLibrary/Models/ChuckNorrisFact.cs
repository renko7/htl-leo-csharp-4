using ChuckNorrisClassLibrary.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChuckNorrisClassLibrary
{
    public class ChuckNorrisFact
    {
        public int Id { get; set; }

        [JsonPropertyName("id")]
        [MaxLength(40)]
        public String ChuckNorrisId { get; set; } = String.Empty;

        [JsonPropertyName("url")]
        [MaxLength(1024)]
        public String Url { get; set; } = String.Empty;

        [JsonPropertyName("value")]
        public String Joke { get; set; } = String.Empty;

        [JsonPropertyName("categories")]
        public List<Category> Categories { get; set; } = new();
    }
}