namespace Tui.WebApplication.FlightClient.Services
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class ApiBaseService
    {
        private String apiBaseUrl;

        private HttpClient httpClient;

        public ApiBaseService(String apiBaseUrl)
        {
            this.httpClient = new HttpClient();
            this.apiBaseUrl = apiBaseUrl;
        }

        async protected Task<T> Get<T>(String uri)
        {
            var responseString = await httpClient.GetStringAsync(apiBaseUrl + uri);
            var response = JsonConvert.DeserializeObject<T>(responseString);

            return response;
        }

        async protected Task Put<T>(String uri, T obj)
        {
            var content = new StringContent(JsonConvert.SerializeObject(obj), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(apiBaseUrl + uri, content);

            response.EnsureSuccessStatusCode();
        }

        async protected Task Post<T>(String uri, T obj)
        {
            var content = new StringContent(JsonConvert.SerializeObject(obj), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiBaseUrl + uri, content);

            response.EnsureSuccessStatusCode();
        }
    }
}
