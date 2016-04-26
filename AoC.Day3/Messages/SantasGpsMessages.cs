namespace AoC.Day3.Messages
{
    public class SantasGpsMessages
    {
        public class ReceivedInstruction
        {
            public char Instruction { get; }

            public ReceivedInstruction(char instruction)
            {
                Instruction = instruction;
            }
        }
    }
}
