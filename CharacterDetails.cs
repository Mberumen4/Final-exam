using System.Collections.Generic;

namespace StarWarsExplorer
{
    // Abstract base class
    public abstract class ApiEntity
    {
        public abstract string DisplayInfo();  // Polymorphic method
    }

    // CharacterDetails now inherits from ApiEntity
    public class CharacterDetails : ApiEntity
    {
        // Properties with getters and setters
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string BirthYear { get; set; }
        public List<string> Starships { get; set; }
        public List<string> Species { get; set; }
        public string Homeworld { get; set; }

        // Constructor to initialize all properties
        public CharacterDetails(string name, string height, string mass, string birthYear, List<string> starships, List<string> species, string homeworld)
        {
            Name = name;
            Height = height;
            Mass = mass;
            BirthYear = birthYear;
            Starships = starships ?? new List<string>();
            Species = species ?? new List<string>();
            Homeworld = homeworld;
        }

        // Polymorphic override of DisplayInfo
        public override string DisplayInfo()
        {
            return $"Name: {Name}, Height: {Height}, Mass: {Mass}, Birth Year: {BirthYear}, Homeworld: {Homeworld}, " +
                   $"Species: {string.Join(", ", Species)}, Starships: {string.Join(", ", Starships)}";
        }
    }
}
