using System;
using Xunit;

namespace StringCalculator2.Test
{
    public class CalculatorAdd
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1,2,3,7,9,15", 37)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//;\n1;2", 3)]        
        public void ReturnsCorrectOutput(string input, int output)
        {
            // Arrange
            Calculator sut = new Calculator();

            //  Act
            var result = sut.Add(input);

            //  Assert
            Assert.Equal(output, result);
        }

        [Theory]
        [InlineData("-1,2", "Negatives not allowed: -1")]
        public void ReturnsErrorMessageForNegativeInputsWithDetails(string input, string output)
        {
            //  Arrange
            Calculator sut = new Calculator();

            //  Act
            var result = sut.Add(input);

            //  Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => sut.Add(input));
            Assert.Equal(output, exception.Message);
        }
        
        
    }
}
