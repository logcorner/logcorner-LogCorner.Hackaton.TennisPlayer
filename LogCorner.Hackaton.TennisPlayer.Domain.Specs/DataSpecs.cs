using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LogCorner.Hackaton.TennisPlayer.Domain.Specs
{
    public class DataSpecs
    {
        [Fact(DisplayName = "create data should init data members")]
        public void CreateCountryShouldInitCountryMembers()
        {
            //Arrange
            int rank = 2;
            int points = 2542;
            int weight = 80000;
            int height = 188;
            int age = 31;
            int[] last = { 1, 1, 1, 1, 1 };

            //Act
            var sut = new Data(rank, points, weight, height, age, last);

            //Assert
            Assert.Equal(rank, sut.Rank);
            Assert.Equal(points, sut.Points);
            Assert.Equal(weight, sut.Weight);
            Assert.Equal(height, sut.Height);
            Assert.Equal(age, sut.Age);
            Assert.Equal(last, sut.Last);
        }

    }
}
