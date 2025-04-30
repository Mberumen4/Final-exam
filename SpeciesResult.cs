using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsExplorer
{
    public class SpeciesResult
    {
        public List<Species> results { get; set; }  // List of species
        public string next { get; set; }            // URL for the next page of species (if applicable)
    }

}
