using System;
using System.IO;
using Akka.Actor;
using AoC.Day1.Actors;
using AoC.Day1.Messages;

namespace AoC.Day1
{
    internal class Program
    {
        private static void Main()
        {
            var actorSystem = ActorSystem.Create("santas-actor-system");

            var elevatorActorRef = actorSystem.ActorOf(Props.Create(() => new ElevatorActor()));
            var santaActorRef = actorSystem.ActorOf(Props.Create(() => new SantaActor(elevatorActorRef)));

            var instructions =
                File
                    .ReadAllText(
                        Path
                            .Combine(
                                Environment.CurrentDirectory,
                                @"App_Data\input.txt"))
                    .ToCharArray();

            santaActorRef.Tell(new SantaMessages.ExecuteInstructions(instructions));

            actorSystem.WhenTerminated.Wait();
        }
    }
}