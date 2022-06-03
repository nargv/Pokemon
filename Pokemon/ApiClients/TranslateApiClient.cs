using Newtonsoft.Json;
using Pokemon.Helpers;
using Pokemon.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokemon.ApiClients
{
    public interface ITranslateClient
    {
        Task<string> GetShakespeareTranslation(string text);
    }

    public sealed class TranslateApiClient : ITranslateClient
    {
        private HttpClient _httpClient;

        public TranslateApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetShakespeareTranslation(string text)
        {
            var response = await _httpClient.GetAsync(StringHelpers.GetTranslationPath("shakespeare", text)).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Translation>(jsonResult);
                return result.Contents.Translated;
            }
            return null;
        }
    }
}
