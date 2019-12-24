using System;

namespace StringCalculator2
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            var total = 0;
            char? extraDelimiter = null;
            if (numbers.StartsWith("//")) extraDelimiter = numbers[2];
            var stringArray = numbers.Split(',','\n', extraDelimiter);
            foreach (var str in stringArray)
            {
                int result;
                int.TryParse(str, out result);
                total += result;
            }

            return total;            
        }
    }
}
