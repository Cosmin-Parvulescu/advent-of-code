using System.Collections.Generic;

namespace AoC.Day4.Messages
{
    public class SupervisorMessages
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
    }
}
