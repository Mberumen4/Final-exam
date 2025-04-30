using System.Collections.Generic;
using Newtonsoft.Json;

namespace StarWarsExplorer
{
    // Class to represent the result of the species API call
    public class SpeciesResult
    {
        // List of species objects that are returned in the API response
        [JsonProperty("results")]
        public List<Species> Results { get; set; }

        // URL to the next page of species data, if available (for paginated results)
        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
