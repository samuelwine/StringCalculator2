using System;
using System.Collections.Generic;
using System.Linq;
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

            var stringArray = ExtractNumericSubStrings(numbers);
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


        private List<string> ExtractNumericSubStrings(string numbers)
        {
            List<string> resultStrings = new List<string>();

            if (Regex.IsMatch(numbers, "^//\\["))
            {
                List<string> delimiterList = new List<string>();

                //  Find all delimiters enclosed by square brackets []
                Regex delimiterRegex = new Regex("\\[[^]]");

                foreach (Match match in delimiterRegex.Matches(numbers))
                {
                    //  remove the enclosing [] from each match
                    var delimiter = match.Value.Trim('[', ']');

                    delimiterList.Add(delimiter);
                }

                //  remove the list of delimiters from the string - leaving just the split-up numbers part of the string
                var cleanedString = Regex.Replace(numbers, "^\\D+", String.Empty);

                var splitStrings = cleanedString.Split(delimiterList.ToArray(), StringSplitOptions.None);
                resultStrings = splitStrings.ToList();
            }

            else if (Regex.IsMatch(numbers, "^//\\D\n"))
            {
                Regex delimiterRegex = new Regex("^//\\D");
                Match match = delimiterRegex.Match(numbers);                
                var delimiter = match.Value.Trim('/');
                var cleanedString = Regex.Replace(numbers, "^//D\n", String.Empty);
                var splitStrings = cleanedString.Split(delimiter);
                resultStrings = splitStrings.ToList();                   
            }           

            else
            {
                var splitStrings = numbers.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
                resultStrings = splitStrings.ToList();                
            }

            return resultStrings;
        }
    }
}
