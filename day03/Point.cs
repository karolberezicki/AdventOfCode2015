namespace day03
{

    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public void Move(char direction)
        {
            switch (direction)
            {
                case '^':
                    X++;
                    break;
                case 'v':
                    X--;
                    break;
                case '>':
                    Y++;
                    break;
                case '<':
                    Y--;
                    break;
                default:
                    break;
            }
        }

        public override int GetHashCode()
        {
            int hash = 23;
            hash = hash * 31 + X.GetHashCode();
            hash = hash * 31 + Y.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            Point point = obj as Point;
            if (point == null) return false;
            return (X == point.X && Y == point.Y);
        }


    }
}
