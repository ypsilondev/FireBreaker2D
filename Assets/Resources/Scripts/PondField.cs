using UnityEngine;

namespace Resources.Scripts
{
    public class PondField : GameField
    {
        public PondField() : base(FieldType.Pond)
        {
        }

        public override void Render()
        {
        }

        public override void RenderSprite(SpriteRenderer renderer)
        {
            renderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/Lake");
        }
    }
}