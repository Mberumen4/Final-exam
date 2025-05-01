using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public static class ApiHelper
{
    private static readonly HttpClient client = new HttpClient();

    // Modify the method to log raw JSON before deserialization
    public static async Task<T> GetDataAsync<T>(string url)
    {
        try
        {
            var response = await client.GetStringAsync(url);

            // Log the raw JSON response
            Console.WriteLine("Raw Response: " + response);

            // Deserialize and return the result
            return JsonConvert.DeserializeObject<T>(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error fetching data: " + ex.Message);
            throw;
        }
    }
}
