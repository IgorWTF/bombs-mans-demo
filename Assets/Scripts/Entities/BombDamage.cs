using System;
using UnityEngine;

namespace Entities
{
    public class BombDamage : MonoBehaviour
    {
        [SerializeField] private Bomb _bomb;
        [SerializeField] private float _explosionDamage;
        [SerializeField] private float _explosionRadius;

        private int _explosionLayerMask;
        private Collider2D[] _explosionResults;

        private void DamageNearObjects()
        {
            var collisions = Physics2D.OverlapCircleNonAlloc(
                transform.position,
                _explosionRadius,
                _explosionResults,
                _explosionLayerMask
            );

            for (var i = 0; i < collisions; i++)
            {
                var gameObj =_explosionResults[i].gameObject;
                var entity = _explosionResults[i].gameObject.GetComponent<Entity>();

                if (entity == null) throw new Exception("The object is configured incorrectly -" + gameObject.name);
            
                entity.Damage(_explosionDamage);
            }
        
            Debug.Log("Damage");
        }

        private void Awake()
        {
            _bomb.EventDie += DamageNearObjects;

            _explosionLayerMask = LayerMask.GetMask("Man");
            _explosionResults = new Collider2D[10];
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _explosionRadius);
        }
    }
}
