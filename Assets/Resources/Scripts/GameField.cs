using System.Collections.Generic;
using UnityEngine;

namespace Resources.Scripts
{
    public abstract class GameField
    {
        private readonly FieldType _fieldType;
        private Stack<FireEngine> _fireEngines;
        private GameObject _obj;

        public GameField(FieldType fieldType)
        { 
            _fieldType = fieldType;
            
            _fireEngines = new Stack<FireEngine>();
        }

        public void SetGameObject(GameObject obj)
        {
            if (_obj != null)
            {
                Debug.Log("Game Object defined twice.");
                return; // ignore
            }
            _obj = obj;
        }

        public abstract void Render();

        public GameObject GetGameObject()
        {
            return _obj;
        }

        public abstract void RenderSprite(SpriteRenderer renderer);


    }
}