using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioClip _takeDamage;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject _spawnEffect;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _lifeBar;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Cartridge _cartridge;
    [SerializeField] private Player _player;
    [SerializeField] private int _speed;
    [SerializeField] private int _hp;

    private float _oldLifeBar;
    private readonly float _x = 1.75f; 

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _oldLifeBar = _lifeBar.localScale.x;
        InvokeRepeating(nameof(Move), 1, 1);
        InvokeRepeating(nameof(GenerateBullet), 1, 3);
    }

    private void GenerateBullet()
    {
        _cartridge.GenerateBullet(_effect, _spawnEffect, _bullet, _speed);
    }

    private void Move()
    {
        var x = Random.Range(-_speed, _speed);
        var y = Random.Range(-_speed, _speed);

        _rigidbody2D.AddForce(new Vector2(x, y) * _speed, ForceMode2D.Force);
    }

    public void TakeDamage(int damage)
    {
        PlayMusic();
        _hp -= damage;
        _healthBar.ChangedHealthBar(_x, _lifeBar, _oldLifeBar, _hp);

        if (_hp <= 0)
        {
            Instantiate(_explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            _player.IncreaseScore();
        }
    }

    private void PlayMusic()
    {
        GetComponent<AudioSource>().PlayOneShot(_takeDamage);
    }
}