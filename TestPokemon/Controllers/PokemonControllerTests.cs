using Microsoft.AspNetCore.Mvc;
using Moq;
using Pokemon.Controllers;
using Pokemon.DataModels.ViewModels;
using Pokemon.Services;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace TestPokemon.Controllers
{
    public class PokemonControllerTests
    {
        private readonly PokemonController pokemonController;
        private readonly Mock<IPokemonService> mockService;

        public PokemonControllerTests()
        {
            mockService = new Mock<IPokemonService>();
            pokemonController = new PokemonController(mockService.Object);
        }

        [Fact]
        public async Task Get_NullName_BadRequest()
        {
            var result = await pokemonController.Get(null) as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task Get_EmptyName_BadRequest()
        {
            var result = await pokemonController.Get(string.Empty) as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task Get_NotFound()
        {
            mockService.Setup(s => s.GetPokemon(It.IsAny<string>())).ReturnsAsync(null as PokemonViewModel);

            var result = await pokemonController.Get("pika") as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
