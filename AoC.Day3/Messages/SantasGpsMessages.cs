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

        public class MoveSledge
        {
            public GpsDirection GpsDirection { get; private set; }

            public MoveSledge(GpsDirection gpsDirection)
            {
                GpsDirection = gpsDirection;
            }
        }
    }
}
