using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace StarWarsExplorer
{
    public partial class Form1 : Form
    {
        // Declare lists to hold favorite characters and planets
        List<string> favoriteCharacters = new List<string>();
        List<string> favoritePlanets = new List<string>();

        // Fields to store the currently fetched planet and person
        private Planet currentPlanet;
        private CharacterDetails currentPerson;

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

                // Store the planet object temporarily for later use
                this.currentPlanet = planet;
            }
            catch (Exception ex)
            {
                // Display error message if fetching planet data fails
                MessageBox.Show("Error fetching planet: " + ex.Message);
            }
        }

        // Event handler for fetching person details
        private async void btnGetPerson_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the input from the user
                string searchInput = txtPersonId.Text.Trim();

                // Check if the input is empty
                if (string.IsNullOrEmpty(searchInput))
                {
                    MessageBox.Show("Please enter a character name or ID.");
                    return;
                }

                // Define the URL for the API
                string url = "";

                // If the input is numeric, search by ID
                if (int.TryParse(searchInput, out int personId))
                {
                    // Construct URL for searching by ID
                    url = $"https://swapi.py4e.com/api/people/{personId}/";
                }
                else
                {
                    // Otherwise, search by name (search query for exact or partial match)
                    string encodedName = Uri.EscapeDataString(searchInput); // URL-encode the name
                    url = $"https://swapi.py4e.com/api/people/?search={encodedName}";
                }

                // Fetch the data from the API
                var searchResult = await ApiHelper.GetDataAsync<PersonResults>(url);

                // Check if the result contains any people
                if (searchResult?.Results?.Count == 0)
                {
                    MessageBox.Show("No character found with that name.");
                    return;
                }

                var person = searchResult?.Results?.FirstOrDefault();

                if (person == null)
                {
                    MessageBox.Show("No character found with that name.");
                    return;
                }

                var starshipNames = new List<string>();
                var speciesNames = new List<string>();

                // Fetch starships
                if (person.Starships != null && person.Starships.Count > 0)
                {
                    foreach (var starshipUrl in person.Starships)
                    {
                        var starship = await ApiHelper.GetDataAsync<Starship>(starshipUrl);
                        if (starship != null)
                            starshipNames.Add(starship.Name);
                    }
                }

                // Fetch species
                if (person.Species != null && person.Species.Count > 0)
                {
                    foreach (var speciesUrl in person.Species)
                    {
                        var species = await ApiHelper.GetDataAsync<Species>(speciesUrl);
                        if (species != null)
                            speciesNames.Add(species.Name);
                    }
                }

                // Fetch homeworld
                string homeworldName = "";
                if (!string.IsNullOrEmpty(person.Homeworld))
                {
                    var homeworld = await ApiHelper.GetDataAsync<Planet>(person.Homeworld);
                    if (homeworld != null)
                        homeworldName = homeworld.Name;
                }

                // Create the CharacterDetails object using the new constructor
                CharacterDetails character = new CharacterDetails(person, starshipNames, speciesNames, homeworldName);

                // Update the UI with the fetched data
                lblPersonName.Text = $"Name: {character.Name}";
                lblHeight.Text = $"Height: {character.Height}";
                lblMass.Text = $"Mass: {character.Mass}";
                lblBirthYear.Text = $"Birth Year: {character.BirthYear}";
                lblSpecies.Text = $"Species: {string.Join(", ", character.Species)}";
                lblHomeworld.Text = $"Homeworld: {character.Homeworld}";

                lstStarships.Items.Clear();
                if (character.Starships.Count > 0)
                {
                    foreach (var ship in character.Starships)
                        lstStarships.Items.Add(ship);
                }
                else
                {
                    lstStarships.Items.Add("No Starships");
                }

                MessageBox.Show(character.DisplayInfo(), "Character Summary");

                // Store the character object temporarily for later use
                this.currentPerson = character;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching character: " + ex.Message);
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

        // Display favorites (characters and planets)
        private void btnShowFavorites_Click(object sender, EventArgs e)
        {
            lstFavorites.Items.Clear();

            // Check if there are any favorites to show
            if (favoriteCharacters.Count == 0 && favoritePlanets.Count == 0)
            {
                lstFavorites.Items.Add("No favorites added yet.");
                return;
            }

            // Display favorite characters
            if (favoriteCharacters.Count > 0)
            {
                lstFavorites.Items.Add("Favorite Characters:");
                foreach (var character in favoriteCharacters)
                {
                    lstFavorites.Items.Add($"- {character}");
                }
            }

            // Display favorite planets
            if (favoritePlanets.Count > 0)
            {
                lstFavorites.Items.Add("Favorite Planets:");
                foreach (var planet in favoritePlanets)
                {
                    lstFavorites.Items.Add($"- {planet}");
                }
            }
        }
        // Placeholder event handler for the species list selection change (currently not used)
        private void lstSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Functionality can be added here if needed
        }

        private void btnAddToFavoritesPlanet_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("Add to Favorites Planet clicked.");
            if (this.currentPlanet != null)
            {
                if (!favoritePlanets.Contains(this.currentPlanet.Name))
                {
                    favoritePlanets.Add(this.currentPlanet.Name);
                    MessageBox.Show($"{this.currentPlanet.Name} added to favorites!");
                }
                else
                {
                    MessageBox.Show("This planet is already in your favorites.");
                }
            }
            else
            {
                MessageBox.Show("No planet to add. Please fetch a planet first.");
            }
        }

        private void btnAddToFavoritesCharacter_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Add to Favorites Character clicked.");

            if (this.currentPerson != null)
            {
                // Debug: Check if the character is already in favorites
                Console.WriteLine($"Current favorite characters: {string.Join(", ", favoriteCharacters)}");

                if (!favoriteCharacters.Contains(this.currentPerson.Name))
                {
                    favoriteCharacters.Add(this.currentPerson.Name);
                    MessageBox.Show($"{this.currentPerson.Name} added to favorites!");

                    // Debug: Check the list content
                    Console.WriteLine("Updated favorite characters: ");
                    foreach (var character in favoriteCharacters)
                    {
                        Console.WriteLine(character);
                    }
                }
                else
                {
                    MessageBox.Show("This character is already in your favorites.");
                }
            }
            else
            {
                MessageBox.Show("No character to add. Please fetch a character first.");
            }
        }
    }
}
