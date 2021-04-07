using Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawners
{
    public sealed class HorizontalEntitySpawner : EntitySpawner
    {
        [SerializeField] private Entity _entityInstance;
        [SerializeField] private float _width;

        public override Entity Spawn()
        {
            var randomPosition = transform.position + Vector3.left * Random.Range(-_width / 2, _width / 2);
            var entity = Instantiate(_entityInstance, randomPosition, Quaternion.identity)
                .GetComponent<Entity>();
            return entity;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position + Vector3.left * _width/2, transform.position - Vector3.left * _width/2 );
        }

        private void Start()
        {
            Spawn();
        }
    }
}
