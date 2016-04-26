using Akka.Actor;
using AoC.Day3.Domain;
using AoC.Day3.Messages;

namespace AoC.Day3.Actors
{
    public class SantasGps : TypedActor, 
        IHandle<SantasGpsMessages.ReceivedInstruction>,
        IHandle<SantasGpsMessages.MoveSledge>
    {
        public void Handle(SantasGpsMessages.ReceivedInstruction message)
        {
            var direction = default(GpsDirection);

            switch (message.Instruction)
            {
                case '^':
                    direction = GpsDirection.North;
                    break;
                case 'v':
                    direction = GpsDirection.South;
                    break;
                case '<':
                    direction = GpsDirection.West;
                    break;
                case '>':
                    direction = GpsDirection.East;
                    break;
            }

            if (direction == default(GpsDirection))
                Self.Tell(new SantasGpsMessages.MoveSledge(direction));
        }

        public void Handle(SantasGpsMessages.MoveSledge message)
        {
            throw new System.NotImplementedException();
        }
    }
}
