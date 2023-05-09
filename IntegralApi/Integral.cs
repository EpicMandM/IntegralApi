using IntegralApi.Model;
using Newtonsoft.Json;
using System.Web;

namespace IntegralApi
{
    public static class Integral
    {
        public static async Task<IntegralModel> GetAsync(string equation)
        {
            string url = $"https://newton.vercel.app/api/v2/integrate/{HttpUtility.UrlEncode(equation)}";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    IntegralModel model =  JsonConvert.DeserializeObject<IntegralModel>(apiResponse) ?? new IntegralModel();
                    model.Operation = url;
                    return model;
                }
            }
        }
    }
}
