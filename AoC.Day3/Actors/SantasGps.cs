using Akka.Actor;
using AoC.Day3.Messages;

namespace AoC.Day3.Actors
{
    public class SantasGps : TypedActor, IHandle<SantasGpsMessages.ReceivedInstruction>
    {
        public void Handle(SantasGpsMessages.ReceivedInstruction message)
        {
            throw new System.NotImplementedException();
        }
    }
}
