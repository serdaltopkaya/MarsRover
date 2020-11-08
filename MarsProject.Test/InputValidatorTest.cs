using MarsProject.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsProject.Test
{
    public class InputValidatorTest
    {

        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public void IsPositiveIntegern_ShouldBeTrue(string input)
        {
            //Act
            var act = InputValidator.IsPositiveInteger(input);

            // Assert
            Assert.True(act);
        }

        [Theory]
        [InlineData("0.1")]
        [InlineData("-2")]
        public void IsPositiveIntegern_ShouldBeFalse(string input)
        {
            //Act
            var act = InputValidator.IsPositiveInteger(input);

            // Assert
            Assert.False(act);
        }


        [Theory]
        [InlineData("S")]
        [InlineData("N")]
        [InlineData("W")]
        [InlineData("E")]
        public void IsInitialCommpassValid_ShouldBeTrue(string input)
        {
            //Act
            var act = InputValidator.IsInitialCommpassValid(input);

            // Assert
            Assert.True(act);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("B")]
        [InlineData("C")]
        [InlineData("D")]
        public void IsInitialCommpassValid_ShouldBeFalse(string input)
        {
            //Act
            var act = InputValidator.IsInitialCommpassValid(input);

            // Assert
            Assert.False(act);
        }



        [Theory]
        [InlineData('S')]
        [InlineData('N')]
        [InlineData('W')]
        [InlineData('E')]
        public void IsInitialCommpassValid_ShouldBeTrue_Char(char input)
        {
            //Act
            var act = InputValidator.IsInitialCommpassValid(input);

            // Assert
            Assert.True(act);
        }

        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('C')]
        [InlineData('D')]
        public void IsInitialCommpassValid_ShouldBeFalse_Char(char input)
        {
            //Act
            var act = InputValidator.IsInitialCommpassValid(input);

            // Assert
            Assert.False(act);
        }


        [Theory]
        [InlineData("LMLMLMLMM")]
        [InlineData("MMRMMRMRRM")]
        public void IsDirectiveListValid_ShouldBeTrue(string input)
        {
            //Act
            var act = InputValidator.IsDirectiveListValid(input);

            // Assert
            Assert.True(act);
        }


        [Theory]
        [InlineData("LMLMLMLMMD")]
        [InlineData("MMRMMRMRRMS")]
        public void IsDirectiveListValid_ShouldBeFalse(string input)
        {
            //Act
            var act = InputValidator.IsDirectiveListValid(input);

            // Assert
            Assert.False(act);
        }


        [Theory]
        [InlineData( 0)]
        [InlineData(90)]
        [InlineData(180)]
        [InlineData(270)]
        public void IsCompassDegreeValid_ShouldBeTrue(int input)
        {
            //Act
            var act = InputValidator.IsCompassDegreeValid(input);

            // Assert
            Assert.True(act);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(200)]
        [InlineData(300)]
        public void IsCompassDegreeValid_ShouldBeFalse(int input)
        {
            //Act
            var act = InputValidator.IsCompassDegreeValid(input);

            // Assert
            Assert.False(act);
        }


    }
}
