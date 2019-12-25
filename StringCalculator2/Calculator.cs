using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator2
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            var total = 0;
            int result;
            
            List<int> negativeValues = new List<int>();

            var delimiterArray = CreateDelimiterArray(numbers);
            var stringArray = numbers.Split(delimiterArray, StringSplitOptions.None);
            foreach (var str in stringArray)
            {                
                int.TryParse(str, out result);                
                if (result < 0) negativeValues.Add(result);
                if (result > 1000) continue;
                else total += result;              
            }

            if (negativeValues.Count > 0)
            {
                var message = "Negatives not allowed: ";
                foreach (var value in negativeValues)
                {
                    message += $"{value},";
                }
                message.TrimEnd(',');
                throw new ArgumentOutOfRangeException(nameof(negativeValues), message);
            }
            else return total;


        }

        private string[] CreateDelimiterArray(string numbers)
        {
            string[] delimiterArray;
            string searchPattern = "^//\\D\n";
            string extendedSearchPattern = "^//[\\D+]";

            if (Regex.IsMatch(numbers, searchPattern))
            {
                delimiterArray = new string[] {",", "\n", numbers[2].ToString()};
            }

            else if (Regex.IsMatch(numbers, extendedSearchPattern))
            {
                var delimiterStartIndex = numbers.IndexOf('[') + 1;
                var delimiterEndIndex = numbers.IndexOf(']') - 1;
                var delimiterLength = delimiterEndIndex - delimiterStartIndex + 1;
                var newDelimiter = numbers.Substring(delimiterStartIndex, delimiterLength);                
                delimiterArray = new string[] { ",", "\n", newDelimiter };
            }

            else
            {
                delimiterArray = new string[] { ",", "\n" };
            }

            return delimiterArray;
        }

        //private string[] ExtractNumericSubStrings(string numbers)
        //{
        //    string[] resultArray;
        //    string[] patterns = { "^//\\D\n", "^//[\\D+]" };
        //    foreach (var pattern in patterns)
        //    {
        //        if (Regex.IsMatch(numbers, pattern))
        //        {
        //            resultArray = 
        //        }
        //    }
        //}
    }
}
