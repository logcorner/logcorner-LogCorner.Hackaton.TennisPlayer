using Moq;
using Xunit;

namespace LogCorner.Hackaton.TennisPlayer.Domain.Specs
{
    public class PlayerSpecs
    {
        [Fact(DisplayName = "create player should init player members")]
        public void CreatePlayerShouldInitPlayerMembers()
        {
            //Arrange
            int id = 52;
            string firstname = "Novak";
            string lastname = "Djokovic";
            string sex = "M";
            string picture = "https://i.eurosport.com/_iss_/person/pp_clubteam/large/565920.jpg";

            Country country = new Country(It.IsAny<string>(), It.IsAny<string>());
            Data data = new Data();

            //Act
            var sut = new Player(id, firstname, lastname, sex, country, picture, data);

            //Assert
            Assert.Equal(id, sut.Id);
            Assert.Equal(firstname, sut.Firstname);
            Assert.Equal(lastname, sut.Lastname);
            Assert.Equal(sex, sut.Sex);
            Assert.Equal(country, sut.Country);
            Assert.Equal(data, sut.Data);
        }
    }
}