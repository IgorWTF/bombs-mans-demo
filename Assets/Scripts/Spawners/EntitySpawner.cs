using Entities;
using UnityEngine;

namespace Spawners
{
    public abstract class EntitySpawner : MonoBehaviour
    {
        public abstract Entity Spawn();
    }
}
