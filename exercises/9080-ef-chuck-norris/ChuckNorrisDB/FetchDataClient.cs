using ChuckNorrisClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChuckNorrisDB
{
    public class FetchDataClient
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<T> GetDataFromEndPoint<T>(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            var responseBody = await response.Content.ReadAsStringAsync();

            var deserializedResponse = JsonSerializer.Deserialize<T>(responseBody);

            return deserializedResponse;
        }
    }
}
