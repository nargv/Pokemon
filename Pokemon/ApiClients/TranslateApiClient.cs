using Newtonsoft.Json;
using Pokemon.Helpers;
using Pokemon.DataModels.Dao;
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
            var response = await _httpClient.GetAsync(StringHelpers.GetTranslationPath(PokemonConstants.Translation.SHAKESPEARE, text)).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TranslationDao>(jsonResult);
                return result.Contents.Translated;
            }
            return null;
        }
    }
}
