using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _speed = 5;
    [SerializeField] private int _hp;
    [SerializeField] private GameObject _expl;
    [SerializeField] private Transform _lifeBar;

    private float _oldLifeBar;

    private void Start()
    {
        _oldLifeBar = _lifeBar.localScale.x;
        InvokeRepeating("Move", 1, 1);
    }

    private void Move()
    {
        var x = Random.Range(-_speed, _speed);
        var y = Random.Range(-_speed, _speed);

        GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * _speed, ForceMode2D.Force);
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        HealthBar();

        if (_hp <= 0)
        {
            Instantiate(_expl, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void HealthBar()
    {
        _lifeBar.localPosition = new Vector2(1.75f * _hp / 100 - 1.75f, _lifeBar.localPosition.y);
        _lifeBar.localScale = new Vector2(_oldLifeBar * _hp / 100, _lifeBar.localScale.y);
    }
}