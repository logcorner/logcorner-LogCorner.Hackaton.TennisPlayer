using LogCorner.Hackaton.TennisPlayer.Domain;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LogCorner.Hackaton.TennisPlayer.Infrastructure.Specs
{
    public class PlayerRepositorySpecs
    {
        [Fact(DisplayName = "GetAsync Shoul Return List Of Players")]
        public async Task GetAsyncShoulReturnListOfPlayers()
        {
            //Arrange
            Mock<IDatabaseProvider> moqDatabaseProvider = new Mock<IDatabaseProvider>();
            List<Player> players = new List<Player>
            {
                new Player(2, "name2", "surname2", "M", It.IsAny<Country>(), "", It.IsAny<Data>())
            };
            moqDatabaseProvider.Setup(d => d.GetPlayers()).Returns(players);
            var sut = new JsonPlayerRepository(moqDatabaseProvider.Object);

            //Act
            var result = await sut.GetAsync();
            //Assert

            Assert.Equal(players, result);
        }
    }
}