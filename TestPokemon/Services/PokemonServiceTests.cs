using Moq;
using PokeApiNet;
using Pokemon.Services;
using Pokemon.ApiClients;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;

namespace TestPokemon.Services
{
    public class PokemonServiceTests
    {
        private readonly PokemonService pokemonService;
        private readonly Mock<IPokemonApiClient> mockPokeClient;
        private readonly Mock<ITranslateClient> mockTranslationClient;

        public PokemonServiceTests()
        {
            mockPokeClient = new Mock<IPokemonApiClient>();
            mockTranslationClient = new Mock<ITranslateClient>();
            pokemonService = new PokemonService(mockPokeClient.Object, mockTranslationClient.Object);
        }

        [Fact]
        public async Task GetPokemon_Null_Fail()
        {
            var result = await pokemonService.GetPokemon(null);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetPokemon_EmptyString_Fail()
        {
            var result = await pokemonService.GetPokemon(string.Empty);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetPokemon_PokemonNotFound_Fail()
        {
            mockPokeClient.Setup(s => s.GetPokemon(It.IsAny<string>())).ReturnsAsync(null as PokeApiNet.Pokemon);

            var result = await pokemonService.GetPokemon("pika");

            mockPokeClient.Verify(x => x.GetPokemon(It.IsAny<string>()));
            mockPokeClient.VerifyNoOtherCalls();
            Assert.Null(result);
        }

        [Fact]
        public async Task GetPokemon_Success()
        {
            string text = "You gave Mr. Tim a hearty meal", shakespeareTranslation = "Thee did giveth mr. Tim a hearty meal";

            var pokemon = new PokeApiNet.Pokemon
            {
                Id = 1,
                Name = "pikachu",
                Sprites = new PokemonSprites { FrontDefault = string.Empty }
            };

            var pokemonSpecies = new PokemonSpecies
            {
                FlavorTextEntries = new List<PokemonSpeciesFlavorTexts>
                {
                    new PokemonSpeciesFlavorTexts { Language = new NamedApiResource<Language> { Name = "en" }, FlavorText = text },
                }
            };

            mockPokeClient.Setup(s => s.GetPokemon(It.IsAny<string>())).ReturnsAsync(pokemon);
            mockPokeClient.Setup(s => s.GetPokemonSpecies(It.IsAny<PokeApiNet.Pokemon>())).ReturnsAsync(pokemonSpecies);
            mockTranslationClient.Setup(s => s.GetShakespeareTranslation(It.IsAny<string>())).ReturnsAsync(shakespeareTranslation);

            var result = await pokemonService.GetPokemon("pikachu");

            mockPokeClient.Verify(s => s.GetPokemon(It.IsAny<string>()));
            mockPokeClient.Verify(s => s.GetPokemonSpecies(It.IsAny<PokeApiNet.Pokemon>()));
            mockPokeClient.VerifyNoOtherCalls();
            mockTranslationClient.Verify(s => s.GetShakespeareTranslation(It.IsAny<string>()));
            mockTranslationClient.VerifyNoOtherCalls();
            Assert.NotNull(result);
            Assert.Equal("pikachu", result.Name);
            Assert.Equal(shakespeareTranslation, result.Description);
        }
    }
}
