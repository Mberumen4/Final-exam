using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FavoriteCharacter
{
    public string Name { get; set; }
    public string Species { get; set; }
    public string Homeworld { get; set; }

    public FavoriteCharacter(string name, string species, string homeworld)
    {
        Name = name;
        Species = species;
        Homeworld = homeworld;
    }
}
