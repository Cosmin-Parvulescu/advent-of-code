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
        private int _neededRibbon = 0;

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
                var giftMaterials = await _elfActorRef.Ask<GiftMaterials>(new ElfMessages.ComputeNeededMaterials(gift));

                _neededGiftPaper += giftMaterials.WrappingPaper;
                _neededRibbon += giftMaterials.Ribbon;

                Console.WriteLine("[TOTAL] Needed gift paper: {0} and needed ribbon: {1}", _neededGiftPaper, _neededRibbon);
            });
        }
    }
}
