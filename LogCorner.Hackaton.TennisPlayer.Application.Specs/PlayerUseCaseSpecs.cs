using LogCorner.Hackaton.TennisPlayer.Domain;
using LogCorner.Hackaton.TennisPlayer.Infrastructure;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LogCorner.Hackaton.TennisPlayer.Application.Specs
{
    public class PlayerUseCaseSpecs
    {
        [Fact(DisplayName = "get playersusecase should return listof players shorted by playerid")]
        public async Task GetPlayersUseCaseShouldReturnListOfPlayersShortedByPlayerId()
        {
            //Arrange
            Mock<IPlayerRepository> mockPlayerRepository = new Mock<IPlayerRepository>();
            IEnumerable<Player> players = new List<Player>
            {
                new Player(2,"name2","surname2","M",It.IsAny<Country>(),"",It.IsAny<Data>() ),
                new Player(1,"name","surname","M",It.IsAny<Country>(),"",It.IsAny<Data>() )
            };
            mockPlayerRepository.Setup(m => m.GetAsync()).Returns(Task.FromResult(players));

            //Act
            IGetPlayersUsesCase sut = new PlayerUseCase(mockPlayerRepository.Object);
            var result = await sut.Handle();

            //Assert
            Assert.Equal(players.OrderBy(p=>p.Id), result);
        }
    }
}