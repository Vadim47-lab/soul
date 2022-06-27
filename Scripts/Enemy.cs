using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _healthObject;
    [SerializeField] private Music _hit;

    public void TakeDamage(int damage)
    {
        _hit.PlayMusic();
        _healthObject.EnemyHealthChanged(damage);
    }
}