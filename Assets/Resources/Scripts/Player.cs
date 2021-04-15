using System.Drawing;

namespace Resources.Scripts
{
    public class Player
    {
        
        private readonly Color _color;
        
        public Player(Color color)
        {
            _color = color;
        }

        public Color GetColor()
        {
            return _color;
        }

        public static Player Red = new Player(Color.Red);

        public static Player Green = new Player(Color.Green);

        public static Player Yellow = new Player(Color.Yellow);

        public static Player Blue = new Player(Color.Blue);
    }
    
}