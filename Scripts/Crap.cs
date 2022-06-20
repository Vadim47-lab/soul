using UnityEngine;

public class Crap : MonoBehaviour
{
    [SerializeField] private Destruction _destruction;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private float _time;
    [SerializeField] private int _damage;

    private void Start()
    {
        Destroy(gameObject, _time);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            _destruction.EffectDestroys(_explosion);
        }
    }
}