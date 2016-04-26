using AoC.Day3.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Day3.Messages
{
    public class SantasMessages
    {
        public class DeliverReport
        {
            public DeliverReport(IDictionary<Coordinates, int> houseLog)
            {
                HouseLog = houseLog;
            }

            public IDictionary<Coordinates, int> HouseLog { get; private set; }
        }
    }
}
