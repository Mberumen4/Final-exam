using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StarWarsExplorer
{
    public partial class Form1 : Form
    {
        // Constructor to initialize the form
        public Form1()
        {
            InitializeComponent();
        }

        // Event handler for fetching planet details
        private async void btnGetPlanet_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse planet ID from the textbox input
                int planetId = int.Parse(txtPlanetId.Text);
                // Build the URL to fetch data from the API for the specified planet
                string url = $"https://swapi.py4e.com/api/planets/{planetId}/";

                // Fetch planet data asynchronously
                var planet = await ApiHelper.GetDataAsync<Planet>(url);

                // Update the UI with the fetched planet information
                lblName.Text = $"Name: {planet.Name}";
                lblClimate.Text = $"Climate: {planet.Climate}";
                lblTerrain.Text = $"Terrain: {planet.Terrain}";
                lblGravity.Text = $"Gravity: {planet.Gravity}";
                lblPopulation.Text = $"Population: {planet.Population}";
            }
            catch (Exception ex)
            {
                // Display error message if fetching planet data fails
                MessageBox.Show("Error fetching planet: " + ex.Message);
            }
        }

        // Event handler for fetching character (person) details
        private async void btnGetPerson_Click(object sender, EventArgs e)
        {
            try
            {
                // Input validation for person ID
                if (!int.TryParse(txtPersonId.Text, out int personId) || personId <= 0)
                {
                    MessageBox.Show("Please enter a valid person ID (positive integer).");
                    return;
                }

                // Build the URL to fetch data from the API for the specified person
                string url = $"https://swapi.py4e.com/api/people/{personId}/";
                // Fetch person data asynchronously
                var person = await ApiHelper.GetDataAsync<Person>(url);

                // Create lists to store starship and species names
                var starshipNames = new List<string>();
                var speciesNames = new List<string>();

                // Fetch starship data if available
                if (person.Starships != null && person.Starships.Count > 0)
                {
                    foreach (var starshipUrl in person.Starships)
                    {
                        var starship = await ApiHelper.GetDataAsync<Starship>(starshipUrl);
                        if (starship != null)
                            starshipNames.Add(starship.Name);
                    }
                }

                // Fetch species data if available
                if (person.Species != null && person.Species.Count > 0)
                {
                    foreach (var speciesUrl in person.Species)
                    {
                        var species = await ApiHelper.GetDataAsync<Species>(speciesUrl);
                        if (species != null)
                            speciesNames.Add(species.Name);
                    }
                }

                // Fetch homeworld data if available
                string homeworldName = "";
                if (!string.IsNullOrEmpty(person.Homeworld))
                {
                    var homeworld = await ApiHelper.GetDataAsync<Planet>(person.Homeworld);
                    if (homeworld != null)
                        homeworldName = homeworld.Name;
                }

                // Create character object polymorphically using the base class ApiEntity
                ApiEntity character = new CharacterDetails(
                    person.Name,
                    person.Height,
                    person.Mass,
                    person.BirthYear,
                    starshipNames,
                    speciesNames,
                    homeworldName
                );

                // Cast the character to CharacterDetails for specific property access
                var cd = character as CharacterDetails;

                // Display the fetched data on the UI
                lblPersonName.Text = $"Name: {cd.Name}";
                lblHeight.Text = $"Height: {cd.Height}";
                lblMass.Text = $"Mass: {cd.Mass}";
                lblBirthYear.Text = $"Birth Year: {cd.BirthYear}";
                lblSpecies.Text = $"Species: {string.Join(", ", cd.Species)}";
                lblHomeworld.Text = $"Homeworld: {cd.Homeworld}";

                // Display starships, if available
                lstStarships.Items.Clear();
                if (cd.Starships.Count > 0)
                {
                    foreach (var ship in cd.Starships)
                        lstStarships.Items.Add(ship);
                }
                else
                {
                    lstStarships.Items.Add("No Starships");
                }

                // Polymorphic method call (DisplayInfo) for character summary
                MessageBox.Show(character.DisplayInfo(), "Character Summary");
            }
            catch (Exception ex)
            {
                // Display error message if fetching person data fails
                MessageBox.Show("Error fetching person: " + ex.Message);
            }
        }

        // Event handler for fetching species data
        private async void btnGetSpecies_Click(object sender, EventArgs e)
        {
            try
            {
                // Disable button to show loading status
                btnGetSpecies.Enabled = false;
                btnGetSpecies.Text = "Loading...";

                // Set the URL for fetching species data
                string url = "https://swapi.py4e.com/api/species/";
                List<Species> allSpecies = new List<Species>();

                // Loop through multiple pages of species data if necessary
                while (!string.IsNullOrEmpty(url))
                {
                    // Fetch species data asynchronously
                    var speciesResult = await ApiHelper.GetDataAsync<SpeciesResult>(url);

                    // Handle failure to fetch species data
                    if (speciesResult == null)
                    {
                        MessageBox.Show("Failed to fetch species data.");
                        return;
                    }

                    // Add the results from this page to the list
                    if (speciesResult.Results != null)
                        allSpecies.AddRange(speciesResult.Results);

                    // Move to the next page of data if available
                    url = speciesResult.Next;
                }

                // Clear existing list and display all fetched species
                lstSpecies.Items.Clear();
                foreach (var species in allSpecies)
                {
                    lstSpecies.Items.Add($"{species.Name} - {species.Classification} - {species.Language}");
                }
            }
            catch (Exception ex)
            {
                // Display error message if fetching species data fails
                MessageBox.Show("Error fetching species: " + ex.Message);
            }
            finally
            {
                // Re-enable the button and reset the text after the operation completes
                btnGetSpecies.Enabled = true;
                btnGetSpecies.Text = "Get Species";
            }
        }

        // Placeholder event handler for the species list selection change (currently not used)
        private void lstSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Functionality can be added here if needed
        }
    }
}
