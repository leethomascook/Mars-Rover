namespace Akqa.MarsRover.Business.Domain
{
    public class Position
    {
        public int X; 
        public int Y;
        public Direction Direction;

        public override bool Equals(object obj)
        {

            if(obj == null)
            {
                return false;
            }

            var comparingObjet = (Position) obj;

            return comparingObjet.Direction == Direction &&
                   (comparingObjet.X == X && (comparingObjet.Y == Y));
        }
    }
}