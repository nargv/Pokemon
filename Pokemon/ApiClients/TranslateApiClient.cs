using Newtonsoft.Json;
using Pokemon.Constants;
using Pokemon.DataModels.Dao;
using Pokemon.Helpers;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokemon.ApiClients
{
    public interface ITranslateApiClient
    {
        Task<string> GetShakespeareTranslation(string text);
    }

    public sealed class TranslateApiClient : ITranslateApiClient
    {
        private HttpClient _httpClient;

        public TranslateApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetShakespeareTranslation(string text)
        {
            var response = await _httpClient.GetAsync(UrlHelper.GetTranslationPath(PokemonConstants.Translation.SHAKESPEARE, text)).ConfigureAwait(false);
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
