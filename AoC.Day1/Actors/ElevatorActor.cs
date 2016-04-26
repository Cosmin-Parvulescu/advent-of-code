using System;
using Akka.Actor;
using AoC.Day1.Messages;

namespace AoC.Day1.Actors
{
    public class ElevatorActor : TypedActor, IHandle<ElevatorMessages.ExecuteInstruction>
    {
        private readonly IActorRef _elevatorDisplayActorRef;
        private readonly IActorRef _elevatorLoggerActorRef;

        private int _floor;
        private int _instructionNo;

        public ElevatorActor()
        {
            _elevatorDisplayActorRef = Context.ActorOf(Props.Create(() => new ElevatorDisplayActor()));
            _elevatorLoggerActorRef = Context.ActorOf(Props.Create(() => new ElevatorLoggerActor()));
        }

        public void Handle(ElevatorMessages.ExecuteInstruction message)
        {
            _instructionNo++;

            switch (message.Instruction)
            {
                case '(':
                    _floor++;
                    break;

                case ')':
                    _floor--;
                    break;
            }

            _elevatorDisplayActorRef.Tell(new ElevatorMessages.ChangeFloor(_floor));
            _elevatorLoggerActorRef.Tell(new ElevatorMessages.InstructionFloorLog(_instructionNo, _floor));
        }
    }
}