using Unity.Mathematics;
using UnityEngine;

namespace Resources.Scripts
{
    public class FireEngine
    {

        private readonly GameGrid _grid;
        private uint2 _position;
        
        private uint _red = 0;
        private uint _blue = 0;
        private uint _yellow = 0;
        private uint _green = 0;
        
        private GameObject _obj;
        private SpriteRenderer _renderer;

        public FireEngine(GameGrid grid, Player player)
        {
            _grid = grid;
            if (player == Player.Red)
            {
                _position = new uint2(1, 1);
                _red++;
            }
            else if (player == Player.Blue)
            {
                _position = new uint2(_grid._size.x - 2, 1);
                _blue++;
            } 
            else if (player == Player.Yellow)
            {
                _position = new uint2(_grid._size.x - 2, _grid._size.y - 2);
                _yellow++;
            }
            else if (player == Player.Green)
            {
                _position = new uint2(1, _grid._size.y - 2);
                _green++;
            }
        }

        public void Update()
        {
            Vector2 pos = new Vector2(_position.x-(_grid._size.x/2), _position.y-(_grid._size.y/2));
            _obj.transform.position = pos;
            
            _renderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/FireEngineRed");
        }
        
        public GameObject GetGameObject()
        {
            _obj = new GameObject("Dings (" + _position.x + ", " + _position.y + ")");
            _renderer = _obj.AddComponent<SpriteRenderer>();
            
            Update();
            
            return _obj;
        }
    }
}