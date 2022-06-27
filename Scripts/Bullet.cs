using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Destruction _destruction;
    [SerializeField] private Health _health;
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
            _health.HealhChanged(_damage);
            _destruction.HitEffect();
        }

        else if (collision.gameObject.TryGetComponent(out Player player))
        {
            _health.HealhChanged(_damage);
            _destruction.HitEffect();
        }
    }
}