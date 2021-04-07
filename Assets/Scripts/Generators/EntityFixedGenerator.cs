using UnityEngine;

namespace Generators
{
    public class EntityFixedGenerator : EntityGenerator
    {
        [SerializeField] private int _maxEntitiesCount;
        private int _curEntitiesCount;

        protected override void Generate()
        {
            if (_curEntitiesCount == _maxEntitiesCount) return;

            _spawner.Spawn().EventDie += () => --_curEntitiesCount;

            ++_curEntitiesCount;
        }
    }
}
