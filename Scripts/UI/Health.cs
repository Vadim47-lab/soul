using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _health;

    public event UnityAction<int> HealthBarChanged;

    public int Value { get; private set; }

    public void OnHealhChanged(int damage)
    {
        Value = _health;
        _health -= damage;
        HealthBarChanged?.Invoke(_health);
    }
}