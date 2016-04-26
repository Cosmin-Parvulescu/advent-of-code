using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using AoC.Day1.Messages;

namespace AoC.Day1.Actors
{
    public class SantaActor : TypedActor, IHandle<SantaMessages.ExecuteInstructions>
    {
        private readonly IActorRef _elevatorActorRef;

        public SantaActor(IActorRef elevatorActorRef)
        {
            _elevatorActorRef = elevatorActorRef;
        }

        public void Handle(SantaMessages.ExecuteInstructions message)
        {
            foreach (var instruction in message.Instructions.ToList())
            {
                _elevatorActorRef.Tell(new ElevatorMessages.ExecuteInstruction(instruction));
            }
        }
    }
}