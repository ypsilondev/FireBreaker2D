using Resources.Scripts;
using Unity.Mathematics;
using UnityEngine;
using Color = System.Drawing.Color;
using Random = Unity.Mathematics.Random;

namespace Scenes
{
    public class Script : MonoBehaviour {

        public uint size;
        public Camera cam;

        private System.Random ran = new System.Random();
        private GameObject[,] map;

        void Start()
        {
            var gameGrid = new GameGrid(new uint2(size, size));
            gameGrid.Generate(42);
            
            cam.orthographicSize = (size+1)/2;
            this.map = new GameObject[size, size];
        
            for (int x = 0; x < size; x++) {
                for (int y = 0; y < size; y++) {
                    GameObject obj = GetResource(x,y);
                    map[x,y] = obj;

                    Vector2 pos = new Vector2(x-(size/2), y-(size/2));
                    obj.transform.position = pos;
                    //colorize(pos, obj);
                }
            }
        }

        private GameObject GetFireEngine(int x, int y)
        {
            GameObject obj = new GameObject("Sprite (" + x + ", " + y + ")");
            SpriteRenderer component = obj.AddComponent<SpriteRenderer>();

            
            
            return obj;
        }

        private GameObject GetResource(int x, int y)
        {
            GameObject obj = new GameObject("Sprite (" + x + ", " + y + ")");
            SpriteRenderer component = obj.AddComponent<SpriteRenderer>();

            if (x == 0 && y == 0) {
                component.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/FireStationYellow");
            } else if (x == 0 && y == size - 1) {
                component.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/FireStationRed");
            } else if (x == size - 1 && y == 0) {
                component.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/FireStationBlue");
            } else if (x == size - 1 && y == size - 1) {
                component.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/FireStationGreen");
            } else {
                if (ran.NextDouble() < 0.1) {
                    component.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/Lake");
                } else {
                    double num = ran.NextDouble();
                    if (num < 0.05) {
                        component.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/Heaviely_Burning");
                    } else if(num < 0.2) {
                        component.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/Slightly_Burning");
                    } else {
                        component.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/Forrest");
                    }
                
                }
            }

            return obj;
        }
    }
}
