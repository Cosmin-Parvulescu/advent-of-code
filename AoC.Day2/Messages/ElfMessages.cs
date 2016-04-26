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

        public class ComputeNeededMaterials
        {
            public Gift Gift { get; }

            public ComputeNeededMaterials(Gift gift)
            {
                Gift = gift;
            }
        }
    }
}
