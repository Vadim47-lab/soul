using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    public event UnityAction<int> HealthBarChanged;

    public void OnHealhChanged(int health)
    {
        HealthBarChanged?.Invoke(health);
    }
}