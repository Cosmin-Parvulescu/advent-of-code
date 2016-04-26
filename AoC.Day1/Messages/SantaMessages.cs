using System.Collections.Generic;

namespace AoC.Day1.Messages
{
    public class SantaMessages
    {
        public class ExecuteInstructions
        {
            public ExecuteInstructions(IEnumerable<char> instructions)
            {
                Instructions = instructions;
            }

            public IEnumerable<char> Instructions { get; }
        }
    }
}