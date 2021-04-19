using UnityEngine;
using Color = System.Drawing.Color;

namespace Resources.Scripts
{
    public class Player
    {
        
        private readonly Color _color;
        private readonly Sprite _sprite;
        
        public Player(Color color, Sprite sprite)
        {
            _color = color;
            _sprite = sprite;
        }

        public Color GetColor()
        {
            return _color;
        }

        public Sprite GetSprite()
        {
            return _sprite;
        }

        public static Player Red = new Player(Color.Red, UnityEngine.Resources.Load<Sprite>("Sprites/FireStationRed"));

        public static Player Green = new Player(Color.Green, UnityEngine.Resources.Load<Sprite>("Sprites/FireStationGreen"));

        public static Player Yellow = new Player(Color.Yellow, UnityEngine.Resources.Load<Sprite>("Sprites/FireStationYellow"));

        public static Player Blue = new Player(Color.Blue, UnityEngine.Resources.Load<Sprite>("Sprites/FireStationBlue"));
    }
    
}