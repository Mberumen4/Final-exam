using System.Collections.Generic;
using Newtonsoft.Json;

public class Person
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("height")]
    public string Height { get; set; }

    [JsonProperty("mass")]
    public string Mass { get; set; }

    [JsonProperty("birth_year")]
    public string BirthYear { get; set; }

    [JsonProperty("starships")]
    public List<string> Starships { get; set; }

    // Add species and homeworld to the Person class
    [JsonProperty("species")]
    public List<string> Species { get; set; }  // List of species URLs

    [JsonProperty("homeworld")]
    public string Homeworld { get; set; }  // URL to the homeworld
}
