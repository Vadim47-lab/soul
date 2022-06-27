using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Destruction _destruction;
    [SerializeField] private Health _health;
    [SerializeField] private Music _hit;

    public event UnityAction ScoreChanged;

    public void TakeDamage(int damage)
    {
        _hit.PlayMusic();
        _health.OnHealhChanged(damage);

        if (_health.Value <= 0)
        {
            _destruction.KillEffect();
            ScoreChanged?.Invoke();
        }
    }
}