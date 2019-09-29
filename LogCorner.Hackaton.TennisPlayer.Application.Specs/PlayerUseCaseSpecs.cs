using LogCorner.Hackaton.TennisPlayer.Domain;
using LogCorner.Hackaton.TennisPlayer.Infrastructure;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LogCorner.Hackaton.TennisPlayer.Application.Specs
{
    public class PlayerUseCaseSpecs
    {
        [Fact(DisplayName = "get playersusecase should return listof players")]
        public async Task GetPlayersUseCaseShouldReturnListOfPlayers()
        {
            //Arrange
            Mock<IPlayerRepository> mockPlayerRepository = new Mock<IPlayerRepository>();
            IEnumerable<Domain.Player> players = new List<Player>
            {
                new Player(1,"name","surname","M",It.IsAny<Country>(),"",It.IsAny<Data>() )
            };
            mockPlayerRepository.Setup(m => m.GetAsync()).Returns(Task.FromResult(players));

            //Act
            IGetPlayersUsesCase sut = new PlayerUseCase(mockPlayerRepository.Object);
            var result = await sut.Handle();

            //Assert
            Assert.Equal(players, result);
        }
    }
}