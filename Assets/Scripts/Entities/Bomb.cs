using UnityEngine;

namespace Entities
{
    public class Bomb : Entity
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Damage(_maxHealth);
        }
    }
}
