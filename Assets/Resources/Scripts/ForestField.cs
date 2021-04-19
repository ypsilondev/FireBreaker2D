using System;
using UnityEngine;

namespace Resources.Scripts
{
    public class ForestField : GameField
    {

        private Boolean _update;
        private ForestState _state;
        private SpriteRenderer _renderer;
        
        public ForestField(ForestState state) : base(FieldType.Forest)
        {
            _state = state;
        }

        public void SetState(ForestState state)
        {
            _update = true;
            _state = state;
        }
        
        public ForestState GetState()
        {
            return _state;
        }

        public override void Render()
        {
            if (_update)
            {
                Update(_renderer);
            }
        }

        private void Update(SpriteRenderer renderer)
        {
            switch (_state)
            {
                case ForestState.Dry:
                {
                    renderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/Forrest");
                    break;   
                }
                case ForestState.Wet:
                {
                    renderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/ForrestWet");
                    break;
                }
                case ForestState.LightlyBurning:
                {
                    renderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/SlightBurning");
                    break;
                }
                case ForestState.HeavilyBurning:
                {
                    renderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/HeavyBurning");
                    break;
                }
            }
        }

        public override void RenderSprite(SpriteRenderer renderer)
        {
            _renderer = renderer;
            Update(renderer);
        }
    }
}