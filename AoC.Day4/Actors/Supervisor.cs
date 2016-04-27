using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Routing;
using AoC.Day4.Messages;

namespace AoC.Day4.Actors
{
    public class Supervisor : TypedActor, IHandle<SupervisorMessages.FindAdventCoinNumber>, IHandle<WorkerMessages.FoundAdventCoinNumberValue>
    {
        private readonly IDictionary<string, IList<int>> _keyValues = new ConcurrentDictionary<string, IList<int>>();

        private readonly int _workerCount;
        private IActorRef _workerRef;

        public Supervisor(int workerCount = 5)
        {
            _workerCount = workerCount;
        }

        protected override void PreStart()
        {
            _workerRef = Context.ActorOf(Props.Create(() => new Worker()));
        }

        public void Handle(SupervisorMessages.FindAdventCoinNumber message)
        {
            var values = message.Input;
            var batchedValues = new List<IEnumerable<int>>();

            var batchSize = values.Count() / _workerCount;

            while (values.Any())
            {
                batchedValues.Add(values.Take(batchSize));
                values = values.Skip(batchSize).ToList();
            }

            Parallel.ForEach(batchedValues, bv =>
            {
                _workerRef.Tell(new WorkerMessages.FindAdventCoinNumber(message.Key, bv));
            });
        }

        public void Handle(WorkerMessages.FoundAdventCoinNumberValue message)
        {
            if (!_keyValues.ContainsKey(message.Key))
                _keyValues.Add(message.Key, Enumerable.Empty<int>().ToList());

            _keyValues[message.Key].Add(message.Value);
            if (_keyValues[message.Key].Min() == message.Value)
            {
                Console.WriteLine($"Found smaller value for key {message.Key}: {message.Value}");
            }
        }
    }
}
