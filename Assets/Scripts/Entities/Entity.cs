using System;
using UnityEngine;

namespace Entities
{
    public class Entity : MonoBehaviour
    {
        #region Public Actions

        public event Action EventSpawn;
        public event Action EventDie;
        public event Action EventChangeHealth;

        #endregion

        #region Public Properties

        public float Health { private set; get; }
        public bool IsLive { private set; get; }

        #endregion

        #region Serialize Fields

        [SerializeField] protected float _startHealth;
        [SerializeField] protected float _maxHealth;

        #endregion

        #region Public Methods

        public virtual void Damage(float value)
        {
            if (!IsLive) return;

            Health = Mathf.Clamp(Health - value, 0, _maxHealth);
            EventChangeHealth?.Invoke();

            if (Health <= 0) Die();
        }

        #endregion

        #region Protected Methods

        protected virtual void Spawn()
        {
            Health = _startHealth;
            IsLive = true;
            EventSpawn?.Invoke();
        }

        protected virtual void Die()
        {
            IsLive = false;
            EventDie?.Invoke();
            Destroy(this.gameObject);
        }

        #endregion

        #region Monobehaviour

        protected void Start()
        {
            Spawn();
        }

        #endregion
    }
}
