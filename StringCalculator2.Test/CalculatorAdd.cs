using System;
using Xunit;

namespace StringCalculator2.Test
{
    public class CalculatorAdd
    {
        public Calculator sut { get; set; } = new Calculator();

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1,2,3,7,9,15", 37)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//;\n1;2", 3)]       
        [InlineData("1001,2", 2)]
        [InlineData("//[|||]1|||2|||3", 6)]
        [InlineData("//[|][%]\n1|2%3", 6)]
        [InlineData("//[||][%%%][::::]\n1||2%%%3::::4", 10)]
        public void ReturnsCorrectOutput(string input, int output)
        {
            //  Act
            var result = sut.Add(input);

            //  Assert
            Assert.Equal(output, result);
        }

        [Theory]
        [InlineData("-1,2", "Negatives not allowed: -1")]
        [InlineData("2,-4,3,-5", "Negatives not allowed: -4,-5")]
        public void ReturnsErrorMessageForNegativeInputsWithDetails(string input, string output)
        {            
            //  Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => sut.Add(input));
            Assert.Contains(output, exception.Message);
        }
        
        
    }
}
