using System;
using Akka.Actor;
using AoC.Day3.Messages;
using System.Collections.Generic;
using AoC.Day3.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace AoC.Day3.Actors
{
    public class MrsClaus : TypedActor, IHandle<SantasMessages.DeliverReport>
    {
        private IDictionary<Coordinates, int> _businessLog = new Dictionary<Coordinates, int>();

        public void Handle(SantasMessages.DeliverReport message)
        {
            foreach(var log in message.HouseLog)
            {
                if (_businessLog.ContainsKey(log.Key))
                    _businessLog[log.Key] += log.Value;
                else
                    _businessLog[log.Key] = log.Value;
            }

            var housesWithMultipleGifts = _businessLog.Where(mg => mg.Value >= 1).ToList();

            Console.Clear();
            Console.WriteLine("{0} houses were nice this year:", housesWithMultipleGifts.Count);
        }
    }
}
