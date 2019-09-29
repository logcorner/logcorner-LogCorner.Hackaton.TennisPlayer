using LogCorner.Hackaton.TennisPlayer.Domain;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
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
            Mock<IConfiguration> moqIConfiguration = new Mock<IConfiguration>();
            string fullFilePath = "";
            moqIConfiguration.Setup(m => m[It.IsAny<string>()]).Returns(fullFilePath);
            List<Player> players = new List<Player>
            {
                new Player(2, "name2", "surname2", "M", It.IsAny<Country>(), "", It.IsAny<Data>())
            };

            var sut = new JsonPlayerRepository(moqIConfiguration.Object);

            //Act
            var result = await sut.GetAsync();
            //Assert

            Assert.Equal(players, result);
        }
    }
}