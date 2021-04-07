using System;
using UnityEngine;

public class Man : MonoBehaviour
{
    public event Action EventSpawn;
    public event Action EventChangeHealth;
    public event Action EventDie;

    public float Health { private set; get; }

    [SerializeField] private float _health;
    
    public virtual void ChangeHealth(float value)
    {
        Health = Mathf.Clamp(Health - value, 0, _health);
        EventChangeHealth?.Invoke();
        
        if(Health <= 0) EventDie?.Invoke();
    }

    private void Spawn()
    {
        Health = _health;
        EventSpawn?.Invoke();
    }

    private void Die()
    {
        EventDie?.Invoke();
    }

    private void Start()
    {
        Spawn();
    }
}
