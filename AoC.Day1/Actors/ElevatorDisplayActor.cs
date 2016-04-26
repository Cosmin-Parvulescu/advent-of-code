using System;
using Akka.Actor;
using AoC.Day1.Messages;

namespace AoC.Day1.Actors
{
    public class ElevatorDisplayActor : TypedActor, IHandle<ElevatorMessages.ChangeFloor>
    {
        public void Handle(ElevatorMessages.ChangeFloor message)
        {
            Console.Clear();

            Console.WriteLine("|-----|");
            Console.WriteLine("|F{0}|", message.Floor.ToString("+000;-000"));
            Console.WriteLine("|-----|");
        }
    }
}