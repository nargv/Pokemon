using Pokemon.Models;
using Pokemon.ApiClients;
using System.Threading.Tasks;
using System.Linq;
using System;
using Pokemon.Helpers;

namespace Pokemon.Services
{
    public interface IPokemonService
    {
        Task<PokemonModel> GetPokemon(string name);
    }

    public sealed class PokemonService : IPokemonService
    {
        private readonly IPokemonApiClient _pokemonClient;
        private readonly ITranslateClient _translateClient;

        public PokemonService(IPokemonApiClient pokeApiWrapper, ITranslateClient translateClient)
        {
            _pokemonClient = pokeApiWrapper;
            _translateClient = translateClient;
        }

        public async Task<PokemonModel> GetPokemon(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                return null;

            var pokemon = await _pokemonClient.GetPokemon(name).ConfigureAwait(false);

            if (pokemon == null)
                return null;

            var description = await GetShakespeareDescription(pokemon).ConfigureAwait(false);

            return new PokemonModel(pokemon.Name, description, pokemon.Sprites.FrontDefault);
        }

        private async Task<string> GetShakespeareDescription(PokeApiNet.Pokemon pokemon)
        {
            var description = await GetDescriptionByPokemon(pokemon).ConfigureAwait(false);

            if (string.IsNullOrEmpty(description))
                return null;

            var result = await _translateClient.GetShakespeareTranslation(description).ConfigureAwait(false);
            return result ?? description;
        }

        private async Task<string> GetDescriptionByPokemon(PokeApiNet.Pokemon pokemon)
        {
            var result = await _pokemonClient.GetPokemonSpecies(pokemon).ConfigureAwait(false);

            if (result == null)
                return null;

            var englishFlavourTexts = result.FlavorTextEntries.Where(x => x.Language.Name == "en").ToList();

            if (englishFlavourTexts.Any())
            {
                var random = new Random();
                var index = random.Next(0, englishFlavourTexts.Count - 1);
                return StringHelpers.RemoveLineBreaks(englishFlavourTexts[index].FlavorText);
            }

            return null;
        }
    }
}
