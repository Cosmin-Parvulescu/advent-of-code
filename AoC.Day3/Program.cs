using System;
using System.IO;
using Akka.Actor;
using AoC.Day3.Actors;
using AoC.Day3.Domain;

namespace AoC.Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("santas-drunk-helper");

            var mrsClausRef = actorSystem.ActorOf(Props.Create(() => new MrsClaus()));
            var santaRef = actorSystem.ActorOf(Props.Create(() => new Santa(mrsClausRef)));
            var roboSantaRef = actorSystem.ActorOf(Props.Create(() => new Santa(mrsClausRef)));

            var santasGpsRef = actorSystem.ActorOf(Props.Create(() => new SantasGps(new[] { santaRef, roboSantaRef })));

            var inputPath = Path.Combine(Environment.CurrentDirectory, @"App_Data\input.txt");
            var santasPath = File.ReadAllText(inputPath);

            foreach (var instruction in santasPath)
                santasGpsRef.Tell(new Messages.SantasGpsMessages.ReceivedInstruction(instruction));
            santasGpsRef.Tell(new Messages.SantasGpsMessages.FinishedReceivingInstructions());

            actorSystem.WhenTerminated.Wait();
        }
    }
}
