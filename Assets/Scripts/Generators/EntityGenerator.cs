using System.Collections;
using Spawners;
using UnityEngine;

namespace Generators
{
    public class EntityGenerator : MonoBehaviour
    {
        [SerializeField] protected EntitySpawner _spawner;
        [SerializeField] protected float _spawnPauseSeconds = 1.0f;

        protected bool gameIsEnded = false;
    
        private IEnumerator GenerateByTime()
        {
            while (!gameIsEnded)
            {
                Generate();
                yield return new WaitForSeconds(_spawnPauseSeconds);
            }   
        }
        protected virtual void Generate()
        {
            _spawner.Spawn();
        }

        protected virtual void Start()
        {
            StartCoroutine(nameof(GenerateByTime));
        }
    }
}
