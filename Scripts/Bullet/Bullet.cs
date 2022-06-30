using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IDamageable
{
    [SerializeField] private DestructionObject _destruction;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _time;
    [SerializeField] private int _damage;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _time);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }

        TakeDamage(_damage);
    }

    public void TakeDamage(int damage)
    {
        _destruction.HitEffect();
    }
}