public class Species
{
    public string Name { get; set; }
    public string Classification { get; set; }
    public string Language { get; set; }

    // to initialize a species
    public Species(string name, string classification, string language)
    {
        Name = name;
        Classification = classification;
        Language = language;
    }
}
