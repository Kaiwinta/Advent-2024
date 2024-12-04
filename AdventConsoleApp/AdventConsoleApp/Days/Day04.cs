using System.Text.RegularExpressions;

namespace AdventConsoleApp.Days
{
    public class Day04 : BaseDay
    {
        private List<string> splittedData = new List<string>();

        private int CheckSurrounding()
        {
            // Ajout d'une double boucle pour les surrounding de -1 à 1 en évitant 0 ; 0
            return 0;
        }

        protected override int Part1()
        {
            int total = 0;

            for (int i = 0; i < splittedData.Count; i++)
            {
                foreach (var match in Regex.EnumerateMatches(splittedData[i], @"X"))
                {
                    total += CheckSurrounding();
                }
            }
            return total;
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
