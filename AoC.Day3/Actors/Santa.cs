using Akka.Actor;
using AoC.Day3.Domain;
using AoC.Day3.Messages;
using System.Collections.Generic;

namespace AoC.Day3.Actors
{
    public class Santa : TypedActor, IHandle<SantasGpsMessages.Inform>, IHandle<SantasGpsMessages.FinishedRoute>
    {
        private Coordinates _currentPosition;
        private IDictionary<Coordinates, int> _houseLog;

        private IActorRef _mrsClaus;

        public Santa(IActorRef mrsClaus)
        {
            _currentPosition = new Coordinates(0, 0);
            _houseLog = new Dictionary<Coordinates, int>();

            _mrsClaus = mrsClaus;
        }

        public void Handle(SantasGpsMessages.Inform message)
        {
            DeliverGift();

            Move(message.Direction);

            DeliverGift();
        }

        public void Handle(SantasGpsMessages.FinishedRoute message)
        {
            _mrsClaus.Tell(new SantasMessages.DeliverReport(_houseLog));
        }

        private void DeliverGift()
        {
            int visits;
            if (!_houseLog.TryGetValue(_currentPosition, out visits))
            {
                visits = 0;

                _houseLog.Add(_currentPosition, visits);
            }

            _houseLog[_currentPosition]++;
        }

        private void Move(GpsDirection direction)
        {
            switch (direction)
            {
                case GpsDirection.North:
                    _currentPosition = new Coordinates(_currentPosition.X, _currentPosition.Y + 1);
                    break;
                case GpsDirection.South:
                    _currentPosition = new Coordinates(_currentPosition.X, _currentPosition.Y - 1);
                    break;
                case GpsDirection.West:
                    _currentPosition = new Coordinates(_currentPosition.X - 1, _currentPosition.Y);
                    break;
                case GpsDirection.East:
                    _currentPosition = new Coordinates(_currentPosition.X + 1, _currentPosition.Y);
                    break;
            }
        }
    }
}
