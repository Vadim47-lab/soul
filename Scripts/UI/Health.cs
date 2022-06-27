using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    public event UnityAction<int> HealthBarChanged;

    int _changedHealth;

    public void HealhChanged(int damage)
    {
        _player.TakeDamage(damage);
        _changedHealth = _enemy.Health;
        OnHealhChanged(_changedHealth);

        _enemy.TakeDamage(damage);
        _changedHealth = _player.Health;
        OnHealhChanged(_changedHealth);
    }

    public void OnHealhChanged(int changedHealth)
    {
        HealthBarChanged?.Invoke(changedHealth);
    }
}