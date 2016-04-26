using System.Linq;
using Akka.Actor;
using AoC.Day2.Messages;

namespace AoC.Day2.Actors
{
    public class ElfActor : TypedActor, IHandle<ElfMessages.ProcessGiftOrder>, IHandle<ElfMessages.ComputeNeededGiftPaper>
    {
        public void Handle(ElfMessages.ProcessGiftOrder message)
        {
            var gift = message.GiftOrder.Split('x');
            ushort length, width, height;
            ushort.TryParse(gift[0], out length);
            ushort.TryParse(gift[1], out width);
            ushort.TryParse(gift[2], out height);

            Sender.Tell(new Gift(length, width, height), Self);
        }

        public void Handle(ElfMessages.ComputeNeededGiftPaper message)
        {
            Sender.Tell(ComputeNeededPaperForGift(message.Gift), Self);
        }

        private int ComputeNeededPaperForGift(Gift gift)
        {
            var extraMaterial = GetSmallestSideArea(gift);

            return 2 * gift.Length * gift.Width +
                   2 * gift.Width * gift.Height +
                   2 * gift.Length * gift.Height +
                   extraMaterial;
        }

        private int GetSmallestSideArea(Gift gift)
        {
            var orderedSideLengths = new[] { gift.Length, gift.Width, gift.Height }.OrderBy(v => v);
            return orderedSideLengths.ElementAt(0) * orderedSideLengths.ElementAt(1);
        }
    }
}
