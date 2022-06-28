using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged;

    public int Value { get; private set; }

    public void OnHealhChanged(int damage)
    {
        _health -= damage;
        Value = _health;
        HealthChanged?.Invoke(_health);
    }
}