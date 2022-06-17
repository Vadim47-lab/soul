using UnityEngine;

public class Crap : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _expl;

    private void Start()
    {
        Destroy(gameObject, _time);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            Instantiate(_expl, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}