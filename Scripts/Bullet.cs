using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _expl;

    private Bullet _bullet;

    private void Start()
    {
        Destroy(gameObject, time);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Instantiate(_expl, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}