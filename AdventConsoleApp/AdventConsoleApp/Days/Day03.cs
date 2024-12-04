using System.Text.RegularExpressions;

namespace AdventConsoleApp.Days
{
    public class Day03 : BaseDay
    {
        private int GetProductOfString(string data)
        {
            int total = 0;
            foreach (var match in Regex.EnumerateMatches(data, @"mul\([0-9]{1,3},[0-9]{1,3}\)"))
            {
                string mul = data.Substring(match.Index, match.Length);

                // Remove the mul(
                int index = mul.IndexOf('(') + 1;
                // Split the string to get only the numbers
                mul = mul.Substring(index, mul.Length - index - 1);
                var values = mul.Split(',');

                total += int.Parse(values[0]) * int.Parse(values[1]);
            }
            return total;
        }

        protected override int Part1()
        {
            return GetProductOfString(Data);
        }

        protected override int Part2()
        {
            int total = 0;

            foreach (var match in Regex.EnumerateMatches(Data, @"(do\(\)((?!don't\(\)).)*mul\([0-9]+,[0-9]+\))"))
            {
                // Search all the mul in a substring that contains only enabled mul
                total += GetProductOfString(Data.Substring(match.Index, match.Length));
            }
            foreach (var match in Regex.EnumerateMatches(Data, @"^(((?!(don't\(\)|do\(\))).)*mul\([0-9]+,[0-9]+\))"))
            {
                // Search all the mul in a substring that contains only enabled mul
                total += GetProductOfString(Data.Substring(match.Index, match.Length));
            }
            return total;
        }
    }
}
