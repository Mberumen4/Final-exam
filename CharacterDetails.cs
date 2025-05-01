using System.Collections.Generic;

namespace StarWarsExplorer
{
    // Abstract base class
    public abstract class ApiEntity
    {
        public abstract string DisplayInfo();  // Polymorphic method
    }

    // CharacterDetails now inherits from ApiEntity
    public class CharacterDetails
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string BirthYear { get; set; }
        public List<string> Starships { get; set; }
        public List<string> Species { get; set; }
        public string Homeworld { get; set; }

        // Constructor that takes a Person object and maps the properties
        public CharacterDetails(Person person, List<string> starships, List<string> species, string homeworld)
        {
            Name = person.Name;
            Height = person.Height;
            Mass = person.Mass;
            BirthYear = person.BirthYear;
            Starships = starships ?? new List<string>();
            Species = species ?? new List<string>();
            Homeworld = homeworld;
        }

        // You can add methods like DisplayInfo, etc.
        public string DisplayInfo()
        {
            return $"{Name} ({BirthYear}) - Height: {Height}, Mass: {Mass}, Species: {string.Join(", ", Species)}";
        }
    }

}
