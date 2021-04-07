using UnityEngine;

namespace Entities
{
    public class Man : Entity
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _damagedColor;

        public override void Damage(float value)
        {
            base.Damage(value);
            _spriteRenderer.color = _damagedColor;
        }

        // TODO
    }
}
