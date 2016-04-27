using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Akka.Actor;
using Akka.Configuration;
using Akka.Routing;
using AoC.Day4.Actors;
using AoC.Day4.Messages;

namespace AoC.Day4
{
    class Program
    {
        private const string Key = "abcdef";

        static void Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("hacker-santa");

            var supervisorRef = actorSystem.ActorOf(Props.Create(() => new Supervisor(5)));
            supervisorRef.Tell(new SupervisorMessages.FindAdventCoinNumber("iwrupvqb", Enumerable.Range(0, 10000000)));
            
            actorSystem.WhenTerminated.Wait();
        }
    }
}
