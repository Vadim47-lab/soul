using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private Destruction _destruction;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _health;

    public event UnityAction<int> HealthBarChanged;
    public event UnityAction ScoreChanged;

    private void OnHealhChanged(int damage)
    {
        _health -= damage;
        HealthBarChanged?.Invoke(_health);
    }

    public void EnemyHealthChanged(int damage)
    {
        OnHealhChanged(damage);

        if (_health <= 0)
        {
            _destruction.KillEffect();
            ScoreChanged?.Invoke();
        }
    }

    public void PlayerHealthChanged(int damage)
    {
        OnHealhChanged(damage);

        if (_health <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }
}