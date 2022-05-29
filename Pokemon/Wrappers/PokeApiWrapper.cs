using PokeApiNet;
using System.Threading.Tasks;

namespace Pokemon.Wrappers
{
    public interface IPokeApiWrapper
    {
        Task<PokeApiNet.Pokemon> GetPokemon(string name);
    }

    public class PokeApiWrapper : IPokeApiWrapper
    {
        private readonly PokeApiClient pokeClient;

        public PokeApiWrapper()
        {
            pokeClient = new PokeApiClient();
        }

        public async Task<PokeApiNet.Pokemon> GetPokemon(string name)
        {
            PokeApiNet.Pokemon pokemon = null;
            try
            {
                pokemon = await pokeClient.GetResourceAsync<PokeApiNet.Pokemon>(name).ConfigureAwait(false);
            }
            catch
            { }

            return pokemon;
        }
    }
}
