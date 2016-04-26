using System;
using System.IO;
using Akka.Actor;
using AoC.Day3.Actors;

namespace AoC.Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("santas-drunk-helper");
            var santasGpsActorRef = actorSystem.ActorOf(Props.Create(() => new SantasGps()));

            var inputPath = Path.Combine(Environment.CurrentDirectory, @"App_Data\input.txt");
            var santasPath = File.ReadAllText(inputPath);

            foreach (var instruction in santasPath)
                santasGpsActorRef.Tell(instruction);

            actorSystem.WhenTerminated.Wait();
        }
    }
}
