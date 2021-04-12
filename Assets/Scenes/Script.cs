using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{

    public int size;
    public Camera cam;

    private System.Random ran = new System.Random();
    private GameObject[,] map;

    void Start()
    {
        cam.orthographicSize = (size+1)/2;
        this.map = new GameObject[size, size];
        
        for (int x = 0; x < size; x++) {
            for (int y = 0; y < size; y++) {
                GameObject obj = getResource(x,y);
                map[x,y] = obj;

                Vector2 pos = new Vector2(x-(size/2), y-(size/2));
                obj.transform.position = pos;
                //colorize(pos, obj);
            }
        }
    }

    private GameObject getResource(int x, int y) {
        GameObject obj = new GameObject("Niemand");
        SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();

        

        if (x == 0 && y == 0) {
            renderer.sprite = Resources.Load<Sprite>("Sprites/Lake");
            renderer.color = Color.red;
        } else if (x == 0 && y == size - 1) {
            renderer.sprite = Resources.Load<Sprite>("Sprites/Lake");
            renderer.color = Color.green;
        } else if (x == size - 1 && y == 0) {
            renderer.sprite = Resources.Load<Sprite>("Sprites/Lake");
            renderer.color = Color.white;
        } else if (x == size - 1 && y == size - 1) {
            renderer.sprite = Resources.Load<Sprite>("Sprites/Lake");
            renderer.color = Color.gray;
        } else {
            if (ran.NextDouble() < 0.1) {
                renderer.sprite = Resources.Load<Sprite>("Sprites/Lake");
            } else {
                renderer.sprite = Resources.Load<Sprite>("Sprites/Lake");
                renderer.color = Color.blue;
            }
        }

        return obj;
    }

}
