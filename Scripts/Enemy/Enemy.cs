using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthBar))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private DestructionObject _destruction;
    [SerializeField] private Music _hit;
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction ScoreChanged;

    public void TakeDamage(int damage)
    {
        _hit.PlayMusic();
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health == 0)
        {
            _destruction.KillEffect();
            ScoreChanged?.Invoke();
        }
    }
}