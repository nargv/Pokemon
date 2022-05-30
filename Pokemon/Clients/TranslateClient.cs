﻿using Newtonsoft.Json;
using Pokemon.Helpers;
using Pokemon.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Pokemon.Clients
{
    public interface ITranslateClient
    {
        Task<string> GetShakespeareTranslation(string text);
    }

    public sealed class TranslateClient : ITranslateClient
    {
        private HttpClient _httpClient;

        public TranslateClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetShakespeareTranslation(string text)
        {
            var response = await _httpClient.GetAsync(StringHelpers.GetTranslationPath("shakespeare", text));
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
