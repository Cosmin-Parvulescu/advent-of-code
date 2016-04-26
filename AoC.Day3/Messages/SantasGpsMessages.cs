using AoC.Day3.Domain;

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

        public class FinishedReceivingInstructions { }

        public class Inform
        {
            public Inform(GpsDirection direction)
            {
                Direction = direction;
            }

            public GpsDirection Direction { get; private set; }
        }

        public class FinishedRoute
        {
            public FinishedRoute()
            {
            }
        }
    }
}
