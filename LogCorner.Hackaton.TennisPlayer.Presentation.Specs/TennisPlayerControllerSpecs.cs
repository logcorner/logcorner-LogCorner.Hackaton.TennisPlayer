using LogCorner.Hackaton.TennisPlayer.Application;
using LogCorner.Hackaton.TennisPlayer.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace LogCorner.Hackaton.TennisPlayer.Presentation.Specs
{
    public class TennisPlayerControllerSpecs
    {
        [Fact(DisplayName = "GetPlayers Should Return Ok")]
        public async Task GetPlayersShouldReturnOk()
        {
            //Arrange
            Mock<IGetPlayersUsesCase> moqGetPlayersUsesCase = new Mock<IGetPlayersUsesCase>();
            var sut = new TennisPlayerController(moqGetPlayersUsesCase.Object);

            //Act
            var result = await sut.Get();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}