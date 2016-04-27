using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using AoC.Day4.Messages;

namespace AoC.Day4.Actors
{
    public class Worker : TypedActor, IHandle<WorkerMessages.FindAdventCoinNumber>
    {
        public async void Handle(WorkerMessages.FindAdventCoinNumber message)
        {
            var supervisorRef = Context.Parent;
            var inputList = message.Input.ToList();

            await Task.Run(() =>
            {
                Parallel.ForEach(inputList, input =>
                {
                    string inputWithKey = $"{message.Key}{input}";
                    string inputWithKeyHash;

                    using (var md5 = MD5.Create())
                        inputWithKeyHash =
                            BitConverter
                                .ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(inputWithKey)))
                                .Replace("-", string.Empty);

                    if (inputWithKeyHash.StartsWith("000000"))
                        supervisorRef.Tell(new WorkerMessages.FoundAdventCoinNumberValue(message.Key, input));
                });
            });

            Console.WriteLine($"Finished processing batch [{inputList.First()} - {inputList.Last()}]");
        }
    }
}
