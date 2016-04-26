namespace AoC.Day3.Domain
{
    public class Coordinates
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Coordinates c = (Coordinates)obj;
            return (X == c.X) && (Y == c.Y);
        }


        public override int GetHashCode()
        {
            return X ^ Y;
        }
    }
}
