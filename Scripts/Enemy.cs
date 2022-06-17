using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioClip _takeDamage;
    [SerializeField] private GameObject _expl;
    [SerializeField] private GameObject _crap;
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject _spawnEffect;
    [SerializeField] private Transform _lifeBar;
    [SerializeField] private Player _player;
    [SerializeField] private int _speed;
    [SerializeField] private int _hp;

    private float _oldLifeBar;

    private void Start()
    {
        _oldLifeBar = _lifeBar.localScale.x;
        InvokeRepeating("Move", 1, 1);
        InvokeRepeating("GenerateCrap", 1, 3);
    }

    private void Move()
    {
        var x = Random.Range(-_speed, _speed);
        var y = Random.Range(-_speed, _speed);

        GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * _speed, ForceMode2D.Force);
    }

    public void TakeDamage(int damage)
    {
        PlayMusic();
        _hp -= damage;
        HealthBar();

        if (_hp <= 0)
        {
            Instantiate(_expl, transform.position, transform.rotation);
            Destroy(gameObject);
            _player.IncreaseScore();
        }
    }

    private void HealthBar()
    {
        _lifeBar.localPosition = new Vector2(1.75f * _hp / 100 - 1.75f, _lifeBar.localPosition.y);
        _lifeBar.localScale = new Vector2(_oldLifeBar * _hp / 100, _lifeBar.localScale.y);
    }

    private void GenerateCrap()
    {
        PlayMusic();
        GameObject eff = Instantiate(_effect, _spawnEffect.transform.position, transform.rotation);
        eff.transform.SetParent(_spawnEffect.transform);
        Vector3 bulletPosition = _spawnEffect.transform.position;
        Vector2 bulletForce;
        float x = _spawnEffect.transform.position.x - transform.position.x;
        float y = _spawnEffect.transform.position.y - transform.position.y;
        bulletForce = new Vector2(x, y);
        GameObject bulletClone = Instantiate(_crap,
            bulletPosition,
            transform.rotation) as GameObject;
        bulletClone.GetComponent<Rigidbody2D>().velocity = bulletForce * _speed;
    }

    private void PlayMusic()
    {
        GetComponent<AudioSource>().PlayOneShot(_takeDamage);
    }
}