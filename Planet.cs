public class Planet
{
    public string Name { get; set; }
    public string Climate { get; set; }
    public string Gravity { get; set; }
    public string Terrain { get; set; }
    public string Population { get; set; }

    // to initialize a planet
    public Planet(string name, string climate, string gravity, string terrain, string population)
    {
        Name = name;
        Climate = climate;
        Gravity = gravity;
        Terrain = terrain;
        Population = population;
    }
}
