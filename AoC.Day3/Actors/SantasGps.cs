using Akka.Actor;
using AoC.Day3.Domain;
using AoC.Day3.Messages;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace AoC.Day3.Actors
{
    public class SantasGps : TypedActor, IHandle<SantasGpsMessages.ReceivedInstruction>, IHandle<SantasGpsMessages.FinishedReceivingInstructions>
    {
        private int currentSubscriberIndex = 0;

        private IEnumerable<IActorRef> _subscribers;

        // I feel like I'm doing something wrong here...
        public SantasGps(IEnumerable<IActorRef> subscribers)
        {
            _subscribers = subscribers;
        }

        public void Handle(SantasGpsMessages.FinishedReceivingInstructions message)
        {
            Parallel.ForEach(_subscribers, (subscriber) =>
            {
                subscriber.Tell(new SantasGpsMessages.FinishedRoute());
            });
        }

        public void Handle(SantasGpsMessages.ReceivedInstruction message)
        {
            // Too lazy to check if subscribers here...
            var subscriber = _subscribers.ElementAt(currentSubscriberIndex++ % _subscribers.Count());

            switch (message.Instruction)
            {
                case '^':
                    subscriber.Tell(new SantasGpsMessages.Inform(GpsDirection.North));
                    break;
                case 'v':
                    subscriber.Tell(new SantasGpsMessages.Inform(GpsDirection.South));
                    break;
                case '<':
                    subscriber.Tell(new SantasGpsMessages.Inform(GpsDirection.West));
                    break;
                case '>':
                    subscriber.Tell(new SantasGpsMessages.Inform(GpsDirection.East));
                    break;
            }
        }
    }
}
