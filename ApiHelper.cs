using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public static class ApiHelper
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<T> GetDataAsync<T>(string url)
    {
        var response = await client.GetStringAsync(url);
        return JsonConvert.DeserializeObject<T>(response);
    }
}
