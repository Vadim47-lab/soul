using UnityEngine;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    public event UnityAction<int> HealthBarChanged;

    private void OnEnable()
    {
        _enemy.HealthChanged += OnHealhChanged;
        _player.HealthChanged += OnHealhChanged;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= OnHealhChanged;
        _player.HealthChanged += OnHealhChanged;
    }

    private void OnHealhChanged(int health)
    {
        HealthBarChanged?.Invoke(health);
    }
}