using Xunit;

namespace LogCorner.Hackaton.TennisPlayer.Domain.Specs
{
    public class CountrySpecs
    {
        [Fact(DisplayName = "create country should init country members")]
        public void CreateCountryShouldInitCountryMembers()
        {
            //Arrange

            string picture = "https://i.eurosport.com/_iss_/geo/country/flag/medium/6944.png";
            string code = "SRB";

            //Act
            var sut = new Country(picture, code);

            //Assert
            Assert.Equal(picture, sut.Picture);
            Assert.Equal(code, sut.Code);
        }
    }
}