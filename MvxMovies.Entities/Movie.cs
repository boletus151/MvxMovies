using Newtonsoft.Json;

namespace MvxMovies.Entities
{
    public class MovieDto
    {
        [JsonProperty("imdbID")]
        public string Id { get; set; }
                
        public string Plot { get; set; }

        [JsonProperty("imdbRating")]
        public decimal Rating { get; set; }

        [JsonProperty("Poster")]
        public string Image { get; set; }

        public string Title { get; set; }
    }
}
