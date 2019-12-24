using System;

namespace StringCalculator2
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            var total = 0;
            char[] delimiterArray;
            if (numbers.StartsWith("//"))
            { 
                delimiterArray = new char[] {',', '\n', numbers[2]};
            }

            else
            {
                delimiterArray = new char[] {',', '\n'};
            }

            var stringArray = numbers.Split(delimiterArray);
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
