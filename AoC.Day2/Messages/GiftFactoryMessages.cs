using System.Collections.Generic;

namespace AoC.Day2.Messages
{
    public class GiftFactoryMessages
    {
        public class HandleGiftOrders
        {
            public IEnumerable<string> GiftOrders { get; }

            public HandleGiftOrders(IEnumerable<string> giftOrders)
            {
                GiftOrders = giftOrders;
            }
        }
    }
}
