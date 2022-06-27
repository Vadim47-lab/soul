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
        _changedHealth = _enemy.Health;
        _player.TakeDamage(damage);
        OnHealhChanged();

        _changedHealth = _player.Health;
        _enemy.TakeDamage(damage);
        OnHealhChanged();
    }

    public void OnHealhChanged()
    {
        HealthBarChanged?.Invoke(_changedHealth);
    }
}