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
            Calculator calculator = new Calculator();

            //  Act
            var result = calculator.Add(input);

            //  Assert
            Assert.Equal(output, result);
        }
        
    }
}
