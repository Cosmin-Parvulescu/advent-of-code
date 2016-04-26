using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Akka.Actor;
using AoC.Day2.Messages;

namespace AoC.Day2.Actors
{
    public class GiftFactoryActor : TypedActor, IHandle<GiftFactoryMessages.HandleGiftOrders>
    {
        private int _neededGiftPaper = 0;

        private readonly IActorRef _elfActorRef;

        public GiftFactoryActor(IActorRef elfActorRef)
        {
            _elfActorRef = elfActorRef;
        }

        public void Handle(GiftFactoryMessages.HandleGiftOrders message)
        {
            Parallel.ForEach(message.GiftOrders, async giftOrder =>
            {
                var gift = await _elfActorRef.Ask<Gift>(new ElfMessages.ProcessGiftOrder(giftOrder));
                var giftNeededWrappingPaper = await _elfActorRef.Ask<int>(new ElfMessages.ComputeNeededGiftPaper(gift));

                _neededGiftPaper += giftNeededWrappingPaper;

                Console.WriteLine("Needed gift paper: {0}", _neededGiftPaper);
            });
        }
    }
}
