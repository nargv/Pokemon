using Moq;
using PokeApiNet;
using Pokemon.Services;
using Pokemon.Wrappers;
using System.Threading.Tasks;
using Xunit;

namespace TestPokemon.Services
{
    public class PokemonServiceTests
    {
        private readonly PokemonService pokemonService;
        private readonly Mock<IPokeApiWrapper> mockPokeApi;

        public PokemonServiceTests()
        {
            mockPokeApi = new Mock<IPokeApiWrapper>();
            pokemonService = new PokemonService(mockPokeApi.Object);
        }

        [Fact]
        public async Task GetPokemon_Null()
        {
            var result = await pokemonService.GetPokemon(null);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetPokemon_EmptyString()
        {
            var result = await pokemonService.GetPokemon(string.Empty);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetPokemon_Success()
        {
            var pokemon = new PokeApiNet.Pokemon
            {
                Id = 1,
                Name = "pikachu",
                Sprites = new PokemonSprites { FrontDefault = string.Empty }
            };

            mockPokeApi.Setup(s => s.GetPokemon(It.IsAny<string>())).ReturnsAsync(pokemon);

            var result = await pokemonService.GetPokemon("pikachu");

            Assert.NotNull(result);
            Assert.Equal("pikachu", result.Name);
        }
    }
}
