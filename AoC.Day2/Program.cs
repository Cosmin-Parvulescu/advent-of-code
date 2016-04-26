using Akka.Actor;

namespace AoC.Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("wrapping-elves");



            actorSystem.WhenTerminated.Wait();
        }
    }
}
