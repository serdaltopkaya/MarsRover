using MarsProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarsProject.Test
{

    public class RoverUtilsTest
    {

        [Theory]
        [InlineData(0, 'E')]
        [InlineData(90, 'N')]
        [InlineData(180, 'W')]
        [InlineData(270, 'S')]
        [InlineData(90, 'L')]
        [InlineData(270, 'R')]
        public void ConvertCompassCharToPositon_ShouldBeInrangeInRangeOf_0_360_And_MutillesOf90(int expected, char input)
        {
            //Act
            var act = RoverUtils.ConvertCompassCharToPositon(input);

           // Assert
            Assert.Equal(expected, act);
        }


        [Theory]
        [InlineData('E', 0)]
        [InlineData('N', 90)]
        [InlineData('W', 180)]
        [InlineData('S', 270)]
        public void ConvertPositionToCompassLetter_ShouldBeOnofCompassLetter(char expected, int input)
        {
            //Act
            var act = RoverUtils.ConvertPositionToCompassLetter(input);

            // Assert
            Assert.Equal(expected, act);
        }


        [Theory]
        [InlineData(180, 270, 'R')]
        [InlineData(180, 90, 'L')]
        public void CalculateDirectionPositionViaUnitCircle_ShouloldBeInRangeOf_0_360_And_MutillesOf90(int expect, int position, char input)
        {

            //Act
            var result = RoverUtils.CalculateDirectionPositionViaUnitCircle(position, input);

            // Assert
            Assert.Equal(result, expect);
        }

        [Theory]
        [InlineData(5, 5, 1, 2, 'N')]
        [InlineData(5, 5, 3, 3, 'E')]
        public void IsMoveDirectiveAvailable_ShouldBeTuruWhenNextStepInPlatoDimention(int plateauX, int plateauY, int roverX, int roverY, char compass )
        {
            //Arrange
            var plateau = new Plateau(plateauX, plateauY);
            var rover = new Rover(roverX, roverY, compass);
            int nextX;
            int nextY;


            //Act
            var act = RoverUtils.IsMoveDirectiveAvailable (plateau, rover, out nextX, out nextY);

            // Assert
            Assert.True(act);
        }

        [Theory]
        [InlineData(5, 5, 1, 5, 'N')]
        [InlineData(5, 5, 5, 3, 'E')]
        public void IsMoveDirectiveAvailable_ShouldBeFalseWhenNextStepInPlatoDimention(int plateauX, int plateauY, int roverX, int roverY, char compass)
        {
            //Arrange
            var plateau = new Plateau(plateauX, plateauY);
            var rover = new Rover(roverX, roverY, compass);
            int nextX;
            int nextY;


            //Act
            var act = RoverUtils.IsMoveDirectiveAvailable(plateau, rover, out nextX, out nextY);

            // Assert
            Assert.False(act);
        }



    }
}
