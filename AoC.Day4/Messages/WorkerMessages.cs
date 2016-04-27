using System.Collections.Generic;

namespace AoC.Day4.Messages
{
    public class WorkerMessages
    {
        public class FindAdventCoinNumber
        {
            public string Key { get; set; }

            public IEnumerable<int> Input { get; set; }

            public FindAdventCoinNumber(string key, IEnumerable<int> input)
            {
                Key = key;
                Input = input;
            }
        }

        public class FoundAdventCoinNumberValue
        {
            public string Key { get; set; }

            public int Value { get; set; }

            public FoundAdventCoinNumberValue(string key, int value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
