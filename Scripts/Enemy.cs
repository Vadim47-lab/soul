using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Destruction _destruction;
    [SerializeField] private Music _hit;
    [SerializeField] private int _health;

    public event UnityAction ScoreChanged;

    public int Health { get; private set; }

    public void TakeDamage(int damage)
    {
        _hit.PlayMusic();
        _health -= damage;
        Health = _health;

        if (_health <= 0)
        {
            _destruction.KillEffect();
            ScoreChanged?.Invoke();
        }
    }
}