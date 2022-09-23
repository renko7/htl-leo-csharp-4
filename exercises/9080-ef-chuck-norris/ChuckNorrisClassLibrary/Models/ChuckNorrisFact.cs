using System.ComponentModel.DataAnnotations;

namespace ChuckNorrisClassLibrary
{
    public class ChuckNorrisFact
    {
        public int Id { get; set; }

        [MaxLength(40)]
        public String ChuckNorrisId { get; set; } = String.Empty;

        [MaxLength(1024)]
        public String Url { get; set; } = String.Empty;

        public String Joke { get; set; } = String.Empty;
    }
}