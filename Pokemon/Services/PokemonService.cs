using Pokemon.Models;
using Pokemon.Wrappers;
using System.Threading.Tasks;
using System.Linq;
using PokeApiNet;
using System;

namespace Pokemon.Services
{
    public interface IPokemonService
    {
        Task<PokemonModel> GetPokemon(string name);
    }

    public class PokemonService : IPokemonService
    {
        private readonly IPokeApiWrapper _pokeApiWrapper;

        public PokemonService(IPokeApiWrapper pokeApiWrapper)
        {
            _pokeApiWrapper = pokeApiWrapper;
        }

        public async Task<PokemonModel> GetPokemon(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                return null;

            var pokemon = await _pokeApiWrapper.GetPokemon(name);

            if (pokemon == null)
                return null;

            var description = await GetDescriptionByPokemon(pokemon);

            return new PokemonModel(pokemon.Name, description, pokemon.Sprites.FrontDefault);
        }

        private async Task<string> GetDescriptionByPokemon(PokeApiNet.Pokemon pokemon)
        {
            var result = await _pokeApiWrapper.GetPokemonSpecies(pokemon);

            if (result == null)
                return string.Empty;

            var englishFlavourTexts = result.FlavorTextEntries.Where(x => x.Language.Name == "en").ToList();

            if (englishFlavourTexts.Any())
            {
                var random = new Random();
                var index = random.Next(0, englishFlavourTexts.Count - 1);
                return englishFlavourTexts[index].FlavorText;
            }

            return string.Empty;
        }
    }
}
