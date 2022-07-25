using MVC_OT.Models;
using Newtonsoft.Json;

namespace MVC_OT.Services;

public class NetworkService
{

    public static async Task<APILoginModel> StdLogin(string user, string pass)
    {
        using (var client = new HttpClient())
        {
            try
            {
                const string baseUrl = "http://ccp-info2.com";
                string function = "/APIMasterCCP/api/GetData/StdLoginCCP" +
                    $"?username={user}&password={pass}";

                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync(function);  // Get http method
                response.EnsureSuccessStatusCode();
                var stringResponse = await response.Content.ReadAsStringAsync();
                APILoginModel result = JsonConvert.DeserializeObject<APILoginModel>(stringResponse);
                return result;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request exception: {e.Message}");
            }
        }
        return null;
    }

}