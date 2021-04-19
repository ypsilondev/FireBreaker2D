using System;
using Resources.Scripts;
using Unity.Mathematics;
using UnityEngine;

namespace Scenes
{
    public class Script : MonoBehaviour {

        public uint size;
        public Camera cam;
        private GameGrid _gameGrid;


        void Start()
        {
            _gameGrid = new GameGrid(new uint2(size, size));
            
            _gameGrid.Generate(187);
            _gameGrid.CreateObjects();
            
            cam.orthographicSize = (size + 1) / 2;
        }

        private void Update()
        {
            _gameGrid.Update();
        }
    }
}
