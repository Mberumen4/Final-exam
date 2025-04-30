using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StarWarsExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGetPlanet_Click(object sender, EventArgs e)
        {
            try
            {
                int planetId = int.Parse(txtPlanetId.Text);
                string url = $"https://swapi.py4e.com/api/planets/{planetId}/";

                var planet = await ApiHelper.GetDataAsync<Planet>(url);

                lblName.Text = $"Name: {planet.name}";
                lblClimate.Text = $"Climate: {planet.climate}";
                lblTerrain.Text = $"Terrain: {planet.terrain}";
                lblGravity.Text = $"Gravity: {planet.gravity}";
                lblPopulation.Text = $"Population: {planet.population}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching planet: " + ex.Message);
            }
        }

        private async void btnGetPerson_Click(object sender, EventArgs e)
        {
            try
            {
                int personId = int.Parse(txtPersonId.Text);
                string url = $"https://swapi.py4e.com/api/people/{personId}/";

                var person = await ApiHelper.GetDataAsync<Person>(url);

                lblPersonName.Text = $"Name: {person.name}";
                lblHeight.Text = $"Height: {person.height}";
                lblMass.Text = $"Mass: {person.mass}";
                lblBirthYear.Text = $"Birth Year: {person.birth_year}";

                lstStarships.Items.Clear();
                if (person.starships != null && person.starships.Count > 0)
                {
                    foreach (var starshipUrl in person.starships)
                    {
                        var starship = await ApiHelper.GetDataAsync<Starship>(starshipUrl);
                        if (starship != null)
                        {
                            lstStarships.Items.Add(starship.name);
                        }
                    }
                }
                else
                {
                    lstStarships.Items.Add("No Starships");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching person: " + ex.Message);
            }
        }

        private async void btnGetSpecies_Click(object sender, EventArgs e)
        {
            try
            {
                btnGetSpecies.Enabled = false;
                btnGetSpecies.Text = "Loading...";

                string url = "https://swapi.py4e.com/api/species/";
                List<Species> allSpecies = new List<Species>();

                while (!string.IsNullOrEmpty(url))
                {
                    var speciesResult = await ApiHelper.GetDataAsync<SpeciesResult>(url);

                    if (speciesResult == null)
                    {
                        MessageBox.Show("Failed to fetch species data.");
                        return;
                    }

                    if (speciesResult.results != null)
                        allSpecies.AddRange(speciesResult.results);

                    url = speciesResult.next;
                }

                lstSpecies.Items.Clear();
                foreach (var species in allSpecies)
                {
                    lstSpecies.Items.Add($"{species.name} - {species.classification} - {species.language}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching species: " + ex.Message);
            }
            finally
            {
                btnGetSpecies.Enabled = true;
                btnGetSpecies.Text = "Get Species";
            }
        }
            private void lstSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This was generated automatically. You can leave it empty.
        }

    }
}

