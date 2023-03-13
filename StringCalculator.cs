using System;
using System.Linq;
using System.Text.RegularExpressions;
namespace stringCalculator
{
     class StringCalculator
    {
        public int Calculate(string number)
        {
            //var splitNames = number.Split(',');
            //if(!splitNames.Any())
            //{
            //    return 0;
            //}
            //if (splitNames.Length == 1) 
            //{ 
            //    if(splitNames[0].Length==0)
            //    {
            //        return 0;
            //    }
            //    return int.Parse(splitNames[0]);
            //}
            //string input = number.ToString();
            //int sum = 0;
            //foreach(var v in input)
            //{
            //    sum += Convert.ToInt32(v);
            //}
            //return sum;
            ////return int.Parse(splitNames[0]) + int.Parse(splitNames[1]) ;
            ///

            if (string.IsNullOrEmpty(number))
            {
                return 0;
            }

            char[] delimiters = { ',', '\n' };
            
            int sum = 0;
            if (number.StartsWith("//"))
            {
                var delimiterString = number.Substring(2, number.IndexOf('\n') + 2);
                var delimiterPattern = Regex.Escape(delimiterString).Replace(@"\[", "").Replace(@"\]", "|");
                delimiters = delimiterPattern.ToCharArray();
                number = number.Substring(number.IndexOf('\n') + 1);
                //int delimiterIndex = number.IndexOf('\n')+1;
                //delimiters = new char[] { number[delimiterIndex] };
                //number = number.Substring(delimiterIndex + 1);
            }
            string[] newNumber = number.Split(delimiters);
            foreach (var v in newNumber)
            {
                int value = int.Parse(v);
                if(value<0 || value>1000)
                {
                    throw new ArgumentException("Negative, 1000+ not allowed");
                }
                sum += value;
            }

            return sum;
        }
    }
}
