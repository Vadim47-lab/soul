using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private DestructionObject _destruction;
    [SerializeField] private Health _health;

    public event UnityAction ScoreChanged;

    public void TakeDamage(int damage)
    {
        _health.OnTakeDamage(damage);

        if (_health.Value <= 0)
        {
            _destruction.KillEffect();
            ScoreChanged?.Invoke();
        }
    }
}