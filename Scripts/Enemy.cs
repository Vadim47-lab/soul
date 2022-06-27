using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Destruction _destruction;
    [SerializeField] private Health _healthObject;
    [SerializeField] private Music _hit;
    [SerializeField] private int _health;

    public event UnityAction ScoreChanged;

    public void TakeDamage(int damage)
    {
        _hit.PlayMusic();
        _health -= damage;
        _healthObject.OnHealhChanged(_health);

        if (_health <= 0)
        {
            _destruction.KillEffect();
            ScoreChanged?.Invoke();
        }
    }
}