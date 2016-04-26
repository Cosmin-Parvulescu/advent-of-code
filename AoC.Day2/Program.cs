using System;
using System.IO;
using Akka.Actor;
using AoC.Day2.Actors;
using AoC.Day2.Messages;

namespace AoC.Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("wrapping-elves");
            var elfActorRef = actorSystem.ActorOf(Props.Create(() => new ElfActor()));
            var giftFactoryActorRef = actorSystem.ActorOf(Props.Create(() => new GiftFactoryActor(elfActorRef)));

            var inputPath = Path.Combine(Environment.CurrentDirectory, @"App_Data\input.txt");
            var giftOrders = File.ReadAllLines(inputPath);

            giftFactoryActorRef.Tell(new GiftFactoryMessages.HandleGiftOrders(giftOrders));

            actorSystem.WhenTerminated.Wait();
        }
    }
}
