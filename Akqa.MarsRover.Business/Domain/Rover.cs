namespace Akqa.MarsRover.Business.Domain
{
    public class Rover
    {
        private readonly Position m_currentPosition; 

        public Rover(Position currentPosition)
        {
            m_currentPosition = currentPosition;
        }

        public void MoveFoward()
        {

            /* Remember, this can be facing in any direction, so you can't just increment the x/y axis */
           switch(m_currentPosition.Direction)
           {
               case Direction.North:
                   m_currentPosition.Y += 1;
                   break;
               case Direction.East:
                   m_currentPosition.X += 1;
                   break;
               case Direction.South:
                   m_currentPosition.Y -= 1;
                   break;
               case Direction.West:
                   m_currentPosition.X -= 1;
                   break;

           }
        }

        public Position GetCurrentPosition()
        {
            return m_currentPosition;
        }

        public void Rotate(Rotation direction)
        {
            switch(direction)
            {
                case Rotation.Left:
                    RotateLeft();
                    break;

                case Rotation.Right:
                    RotateRight();
                    break;
            }
        }

        private void RotateRight()
        {
            switch(m_currentPosition.Direction)
            {
                case Direction.North:
                    m_currentPosition.Direction = Direction.East;
                    break;
                case Direction.East:
                    m_currentPosition.Direction = Direction.South;
                    break;
                case Direction.South:
                    m_currentPosition.Direction = Direction.West;
                    break;
                case Direction.West:
                    m_currentPosition.Direction = Direction.North;
                    break;
            }
        }

        private void RotateLeft()
        {
            switch (m_currentPosition.Direction)
            {
                case Direction.North:
                    m_currentPosition.Direction = Direction.West;
                    break;
                case Direction.East:
                    m_currentPosition.Direction = Direction.North;
                    break;
                case Direction.South:
                    m_currentPosition.Direction = Direction.East;
                    break;
                case Direction.West:
                    m_currentPosition.Direction = Direction.South;
                    break;
            }
        }
    }
}
