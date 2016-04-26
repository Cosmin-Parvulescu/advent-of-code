using System;
using System.Threading;
using Akka.Actor;
using AoC.Day1.Messages;

namespace AoC.Day1.Actors
{
    public class ElevatorLoggerActor : TypedActor, IHandle<ElevatorMessages.InstructionFloorLog>
    {
        public void Handle(ElevatorMessages.InstructionFloorLog message)
        {
            if (message.FloorResult != -1)
                return;

            Console.WriteLine("Instruction #{0} took you to the basement. That's scary!", message.InstructionNo);
        }
    }
}