using System.Collections.Generic;
using LogCorner.Hackaton.TennisPlayer.Application;
using LogCorner.Hackaton.TennisPlayer.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using LogCorner.Hackaton.TennisPlayer.Domain;
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

            IEnumerable<Player> players = new List<Player>();
            moqGetPlayersUsesCase.Setup(m => m.Handle()).Returns(Task.FromResult(players));
            var sut = new TennisPlayerController(moqGetPlayersUsesCase.Object,It.IsAny<IGetPlayerUsesCase>());

            //Act
            var result = await sut.Get();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact(DisplayName = "GetPlayers Should Return Ok")]
        public async Task GetPlayerShouldReturnOk()
        {
            //Arrange
            Mock<IGetPlayerUsesCase> moqGetPlayerUsesCase = new Mock<IGetPlayerUsesCase>();
            var player = new Player(2, "name2", "surname2", "M", It.IsAny<Country>(), "", It.IsAny<Data>());
            moqGetPlayerUsesCase.Setup(m => m.Handle(It.IsAny<PlayerRequest>())).Returns(Task.FromResult(player));
            var sut = new TennisPlayerController(It.IsAny<IGetPlayersUsesCase>(), moqGetPlayerUsesCase.Object);

            //Act
            var result = await sut.Get(player.Id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}