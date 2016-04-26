namespace AoC.Day1.Messages
{
    public class ElevatorMessages
    {
        public enum ElevatorDirection
        {
            Up,
            Down
        }

        public class ExecuteInstruction
        {
            public ExecuteInstruction(char instruction)
            {
                Instruction = instruction;
            }

            public char Instruction { get; set; }
        }

        public class ChangeFloor
        {
            public ChangeFloor(int floor)
            {
                Floor = floor;
            }

            public int Floor { get; }
        }

        public class InstructionFloorLog
        {
            public InstructionFloorLog(int instructionNo, int floorResult)
            {
                InstructionNo = instructionNo;
                FloorResult = floorResult;
            }

            public int InstructionNo { get; }

            public int FloorResult { get; }
        }
    }
}