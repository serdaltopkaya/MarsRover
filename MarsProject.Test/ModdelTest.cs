using MarsProject.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Xunit;
using Newtonsoft;
using Newtonsoft.Json;

namespace MarsProject.Test
{
    public class ModdelTest
    {

        [Theory]
        [InlineData(5, 5)]
        [InlineData(1, 8)]
        [InlineData(2, 7)]
        public void Plateau_ShouldCreateSuccessful(int inputX, int inputY)
        {
            //Arrange
            var arrange = new Action(() =>
            {
                new Plateau(inputX, inputY);
            });


            //Act

            // Assert
            Assert.NotNull(arrange);
        }



        [Theory]
        [InlineData(-5, 5)]
        [InlineData(1, 0)]
        [InlineData(2.2, -1)]
        public void Plateau_ShouldNotCreat(int inputX, int inputY)
        {
            //Arrange
            var arrange = new Action(() =>
            {
                new Plateau(inputX, inputY);
            });


            //Act

            // Assert
            Assert.Throws<ArgumentException>(arrange);
        }




        [Theory]
        [InlineData(5, 5, 'S')]
        [InlineData(1, 2, 'E')]
        [InlineData(2, 4, 'W')]
        public void Rover_ShouldCreateSuccessful(int inputX, int inputY, char compass)
        {
            //Arrange
            var arrange = new Action(() =>
            {
                new Rover(inputX, inputY, compass);
            });


            //Act

            // Assert
            Assert.NotNull(arrange);
        }



        [Theory]
        [InlineData(-5, 5, 'S')]
        [InlineData(1, 0, 'E')]
        [InlineData(2.2, -1, 'W')]
        public void Rover_ShouldNotCreat(int inputX, int inputY, char compass)
        {
            //Arrange
            var arrange = new Action(() =>
            {
                new Rover(inputX, inputY, compass);
            });



            // Assert
            Assert.Throws<ArgumentException>(arrange);
        }



        [Theory]
        [InlineData(5, 5, 'S', "MMRMMRMRRM")]
        [InlineData(1, 2, 'E', "LMLMLMLMM")]
        public void SetDirections_ShouldSetDirectionSeccessful(int inputX, int inputY, char compass, string direction)
        {
            //Arrange
            var rover = new Rover(inputX, inputY, compass);

            //Act
            rover.SetDirections(direction);

            // Assert
            Assert.True(rover.WaitindDirectionsCount == direction.Length);
        }



        [Theory]
        [InlineData(5, 5, 'S', "MMRMMRMRRMD")]
        [InlineData(1, 2, 'E', "LMLMLMLMMS")]
        public void SetDirections_ShouldNotSetDirection(int inputX, int inputY, char compass, string direction)
        {
            //Arrange
            var rover = new Rover(inputX, inputY, compass);

            //Act
            var act = new Action(() =>
            {
                rover.SetDirections(direction);
            });


            // Assert
            Assert.Throws<ArgumentException>(act);
        }


        [Theory]
        [InlineData(5, 5, 1, 2, 'N', "LMLMLMLMM", 1, 3, 'N')]
        [InlineData(5, 5, 3, 3, 'E', "MMRMMRMRRM", 5, 1, 'E')]
        public void ApplayDirectives_ShouldReturnWaitingCoordinatAndCompass(int plateauX, int plateauY, int roverX, int roverY, char compass, string directives, int expectedX, int expectedY, char expectedCompass)
        {
            //Arrange
            var plateau = new Plateau(plateauX, plateauY);
            var rover = new Rover(roverX, roverY, compass);
            rover.SetDirections(directives);
            var expectRover = new Rover(expectedX, expectedY, expectedCompass);

            //Act
            rover.ApplyDirectivesOnSpecifiedPlateau(plateau);


            // Assert
            Assert.Equal(JsonConvert.SerializeObject(expectRover), JsonConvert.SerializeObject(rover));
        }



        [Theory]
        [InlineData(5, 5, 1, 2, 'N', "LMLMLMLMM", 1, 3, 'S')]
        [InlineData(5, 5, 3, 3, 'E', "MMRMMRMRRM", 5, 1, 'W')]
        public void ApplayDirectives_ShouldBeDifferenceObject(int plateauX, int plateauY, int roverX, int roverY, char compass, string directives, int expectedX, int expectedY, char expectedCompass)
        {
            //Arrange
            var plateau = new Plateau(plateauX, plateauY);
            var rover = new Rover(roverX, roverY, compass);
            rover.SetDirections(directives);
            var expectRover = new Rover(expectedX, expectedY, expectedCompass);

            //Act
            rover.ApplyDirectivesOnSpecifiedPlateau(plateau);


            // Assert
            Assert.NotEqual(JsonConvert.SerializeObject(expectRover), JsonConvert.SerializeObject(rover));
        }
    }
}
