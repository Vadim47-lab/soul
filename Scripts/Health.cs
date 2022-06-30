using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthBar))]
public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private Music _hit;
    [SerializeField] private int _minHealth;
    [SerializeField] private int _maxHealth;

    public event UnityAction<int> HealthChanged;

    public int Value { get; private set; }

    private void Start()
    {
        Value = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _hit.PlayMusic();
        Value -= damage;
        Value = Mathf.Clamp(Value, _minHealth, _maxHealth);
        HealthChanged?.Invoke(Value);
    }
}