namespace AdventConsoleApp.Days
{
    public class Day05 : BaseDay
    {
        private List<string> splittedData = new List<string>();
        private Dictionary<int, Rules> orderingRules = new Dictionary<int, Rules>();

        private class Rules
        {
            public int myValue { get; set; }

            public IEnumerable<int> afterMe { get; set; } = Enumerable.Empty<int>();
        }

        private int GetUpdateMiddleIfValid(string line)
        {
            var strValues = line.Split(',');
            List<int> values = strValues.Select(str => int.Parse(str)).ToList();

            for (int i = 0; i < values.Count; i++)
            {
                if (!orderingRules.ContainsKey(values[i])) { continue; }
                var afterMe = orderingRules[values[i]].afterMe;
                var beforeValues = values.Slice(0, i);
                if (beforeValues.Any(val => afterMe.Any(after => after == val)))
                {
                    return 0;
                }
            }
            return values[(values.Count - 1) / 2];
        }

        private bool CheckIfValid(List<int> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if (!orderingRules.ContainsKey(values[i])) { continue; }
                var afterMe = orderingRules[values[i]].afterMe;
                var beforeValues = values.Slice(0, i);
                if (beforeValues.Any(val => afterMe.Any(after => after == val)))
                {
                    return false;
                }
            }
            return true;
        }

        private int OrderIfInvalid(string line)
        {
            var strValues = line.Split(',');
            List<int> values = strValues.Select(str => int.Parse(str)).ToList();

            if (CheckIfValid(values))
            {
                return 0;
            }

            for (int i = 0; i < values.Count; i++)
            {
                if (!orderingRules.ContainsKey(values[i])) { continue; }
                var afterMe = orderingRules[values[i]].afterMe;
                var beforeValues = values.Slice(0, i);
                for (int j = 0; j < beforeValues.Count; j++)
                {
                    if (afterMe.Any(val => val == beforeValues[j]))
                    {
                        var save = values[i];
                        values[i] = values[j];
                        values[j] = save;
                    }
                }
            }
            if (CheckIfValid(values))
            {
                return values[(values.Count - 1) / 2];
            }
            throw new Exception($"An error occured during the sort with values {values}");
        }

        private int ParseAndComputeResult(Func<string, int> ComputeResult)
        {
            int total = 0;
            bool isRuleDefinitions = true;
            splittedData = Data.Split('\n').ToList();

            foreach (var line in splittedData)
            {
                if (line == String.Empty || line.Equals("\r"))
                {
                    isRuleDefinitions = false;
                    continue;
                }
                if (isRuleDefinitions)
                {
                    var values = line.Split('|');
                    var before = int.Parse(values[0]);
                    var after = int.Parse(values[1]);

                    if (!orderingRules.ContainsKey(before))
                    {
                        // Creation of an element in the dictionnary
                        orderingRules.Add(before, new Rules() { myValue = before });
                    }
                    // Update of the rule
                    orderingRules[before].afterMe = orderingRules[before].afterMe.Append(after);
                }
                else
                {
                    total += ComputeResult(line);
                }
            }
            return total;
        }

        protected override int Part1()
        {
            return ParseAndComputeResult(GetUpdateMiddleIfValid);
        }

        protected override int Part2()
        {
            return ParseAndComputeResult(OrderIfInvalid);
        }
    }
}
