using IntegralApi.Model;
using Newtonsoft.Json;
using System.Web;

namespace IntegralApi
{
    static class Integral
    {
        public static async Task<string> Get(string equation)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://newton.vercel.app/api/v2/integrate/{HttpUtility.UrlEncode(equation)}"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IntegralModel>(apiResponse)?.Result ?? "";
                }
            }
        }
    }
}
