using System.Text.RegularExpressions;

namespace AdventConsoleApp.Days
{
    public class Day04 : BaseDay
    {
        private List<string> splittedData = new List<string>();

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

        private char? GetCharIfPossible(int lineIndex, int colsIndex)
        {
            try
            {
                return splittedData[lineIndex][colsIndex];
            }
            catch
            {
                return null;
            }
        }

        private bool IsXPattern(int lineIndex, int colsIndex)
        {
            var topRight = GetCharIfPossible(lineIndex - 1, colsIndex + 1);
            var topLeft  = GetCharIfPossible(lineIndex - 1, colsIndex - 1);
            var botRight = GetCharIfPossible(lineIndex + 1, colsIndex + 1);
            var botLeft  = GetCharIfPossible(lineIndex + 1, colsIndex - 1);

            if (topRight == null || topLeft == null || botRight == null || botLeft == null)
            {  return false; }

            if ((topRight == topLeft && botRight == botLeft) || (topLeft == botLeft && topRight == botRight))
            {
                string temp = $"{topRight}{botLeft}";
                return temp.Any(c => c == 'M') && temp.Any(c => c == 'S');
            }
            return false;
        }

        protected override int Part2()
        {
            int total = 0;
            splittedData = Data.Split('\n').ToList();

            for (int i = 0; i < splittedData.Count; i++)
            {
                foreach (var match in Regex.EnumerateMatches(splittedData[i], @"A"))
                {
                    total += IsXPattern(i, match.Index) ? 1 : 0;
                }
            }
            return total;
        }
    }
}
