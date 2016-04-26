namespace AoC.Day2.Messages
{
    public class ElfMessages
    {
        public class ProcessGiftOrder
        {
            public string GiftOrder { get; }

            public ProcessGiftOrder(string giftOrder)
            {
                GiftOrder = giftOrder;
            }
        }

        public class ComputeNeededGiftPaper
        {
            public Gift Gift { get; }

            public ComputeNeededGiftPaper(Gift gift)
            {
                Gift = gift;
            }
        }
    }
}
