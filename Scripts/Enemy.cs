using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Destruction _destruction;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Hit _hit;
    [SerializeField] private int _health;

    public event UnityAction ScoreChanged;

    public void TakeDamage(int damage)
    {
        _hit.PlayHit();
        _health -= damage;
        _healthBar.ChangedHealthBar(_health);

        if (_health <= 0)
        {
            _destruction.KillEffect();
            ScoreChanged?.Invoke();
        }
    }
}