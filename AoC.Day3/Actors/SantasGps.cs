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
            switch (message.Instruction)
            {
                case '^':
                    Self.Tell(new SantasGpsMessages.MoveSledge(GpsDirection.North));
                    break;
                case 'v':
                    Self.Tell(new SantasGpsMessages.MoveSledge(GpsDirection.South));
                    break;
                case '<':
                    Self.Tell(new SantasGpsMessages.MoveSledge(GpsDirection.West));
                    break;
                case '>':
                    Self.Tell(new SantasGpsMessages.MoveSledge(GpsDirection.East));
                    break;
            }
        }

        public void Handle(SantasGpsMessages.MoveSledge message)
        {
            throw new System.NotImplementedException();
        }
    }
}
