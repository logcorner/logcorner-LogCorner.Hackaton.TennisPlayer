﻿using LogCorner.Hackaton.TennisPlayer.Application.Exceptions;
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
        [Fact(DisplayName = "getplayers usecase should return listof players shorted by playerid")]
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
            Assert.Equal(players.OrderBy(p => p.Id), result);
        }

        [Fact(DisplayName = "getplayer usecase with player request null should raise argumentnullapplicationexception")]
        public async Task GetPlayerUseCaseWithPlayerRequestNullShouldRaiseArgumentNullApplicationException()
        {
            //Arrange
            Mock<IPlayerRepository> mockPlayerRepository = new Mock<IPlayerRepository>();

            var player = new Player(2, "name2", "surname2", "M", It.IsAny<Country>(), "", It.IsAny<Data>());

            mockPlayerRepository.Setup(m => m.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(player));

            //Act
            //Assert
            IGetPlayerUsesCase sut = new PlayerUseCase(mockPlayerRepository.Object);
            await Assert.ThrowsAsync<ArgumentNullApplicationException>(() => sut.Handle(null));
        }

        [Fact(DisplayName = "getplayer usecase should return one player")]
        public async Task GetPlayerUseCaseShouldReturnOnePlayer()
        {
            //Arrange
            Mock<IPlayerRepository> mockPlayerRepository = new Mock<IPlayerRepository>();

            var player = new Player(2, "name2", "surname2", "M", It.IsAny<Country>(), "", It.IsAny<Data>());

            mockPlayerRepository.Setup(m => m.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(player));

            //Act
            IGetPlayerUsesCase sut = new PlayerUseCase(mockPlayerRepository.Object);
            var result = await sut.Handle(new PlayerRequest(player.Id));

            //Assert
            Assert.Equal(player, result);
        }
    }
}