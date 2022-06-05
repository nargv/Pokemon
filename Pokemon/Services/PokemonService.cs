using Pokemon.DataModels.ViewModels;
using Pokemon.ApiClients;
using System.Threading.Tasks;
using System.Linq;
using System;
using Pokemon.Helpers;
using Pokemon.Constants;

namespace Pokemon.Services
{
    public interface IPokemonService
    {
        Task<PokemonViewModel> GetPokemon(string name);
    }

    public sealed class PokemonService : IPokemonService
    {
        private readonly IPokemonApiClient _pokemonClient;
        private readonly ITranslateApiClient _translateClient;

        public PokemonService(IPokemonApiClient pokeApiWrapper, ITranslateApiClient translateClient)
        {
            _pokemonClient = pokeApiWrapper;
            _translateClient = translateClient;
        }

        public async Task<PokemonViewModel> GetPokemon(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                return null;

            var pokemon = await _pokemonClient.GetPokemon(name);

            if (pokemon == null)
                return null;

            var description = await GetShakespeareDescription(pokemon);

            return new PokemonViewModel(pokemon.Name, description, pokemon.Sprites.FrontDefault);
        }

        private async Task<string> GetShakespeareDescription(PokeApiNet.Pokemon pokemon)
        {
            var description = await GetDescriptionByPokemon(pokemon);

            if (string.IsNullOrEmpty(description))
                return null;

            var result = await _translateClient.GetShakespeareTranslation(description);
            return result ?? description;
        }

        private async Task<string> GetDescriptionByPokemon(PokeApiNet.Pokemon pokemon)
        {
            var result = await _pokemonClient.GetPokemonSpecies(pokemon);

            if (result == null)
                return null;

            var englishFlavourTexts = 
                result.FlavorTextEntries
                .Where(x => x.Language.Name == PokemonConstants.Language.EN)
                .Select(x => x.FlavorText)
                .ToList();

            if (englishFlavourTexts.Any())
            {
                var random = new Random();
                var index = random.Next(0, englishFlavourTexts.Count - 1);
                return StringHelper.RemoveLineBreaks(englishFlavourTexts[index]);
            }

            return null;
        }
    }
}
