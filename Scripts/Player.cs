using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip _shoot;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject _spawn;
    [SerializeField] private Transform _lifeBar;
    [SerializeField] private AmountEnemy _amountEnemy;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _speed;
    [SerializeField] private int _hp;
    [SerializeField] private float _rof;
    [SerializeField] private float _random;
    [SerializeField] private int _countEnemy;

    private int _score;
    private float _time;
    private float _oldLifeBar;

    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Exit")
        {
            _countEnemy = 24;
        }

        if (SceneManager.GetActiveScene().name == "Soul")
        {
            _countEnemy = 8;
        }

        _amountEnemy.ShowAmountEnemy(_countEnemy);
        _oldLifeBar = _lifeBar.localScale.x;
        _time = 0;
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Vector3 Scaler = transform.localScale;
        if (angle < -90 && angle > 90)
        {
            Scaler.y = Mathf.Abs(Scaler.y);
        }
        else
        {
            Scaler.y = -Mathf.Abs(Scaler.y);
        }
        transform.localScale = Scaler;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        if (Input.GetMouseButton(0) && _time <= 0)
        {
            GenerateBullet();

            _time = _rof;
        }

        _time -= Time.deltaTime;
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
        DefeatedEnemy();
    }

    public void TakeDamage(int damage)
    {
        PlayMusic();
        _hp -= damage;
        HealthBar();

        if (_hp <= 0)
        {
            Instantiate(_explosion, transform.position, transform.rotation);
            SceneManager.LoadScene(4);
        }
    }

    private void HealthBar()
    {
        _lifeBar.localPosition = new Vector2(1.75f * _hp / 100 - 1.75f, _lifeBar.localPosition.y);
        _lifeBar.localScale = new Vector2(_oldLifeBar * _hp / 100, _lifeBar.localScale.y);
    }

    public void DefeatedEnemy()
    {
        if (_score == _countEnemy && SceneManager.sceneCount == 1)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void GenerateBullet()
    {
        PlayMusic();
        GameObject eff = Instantiate(_effect, _spawn.transform.position, transform.rotation);
        eff.transform.SetParent(_spawn.transform);
        Vector3 bulletPosition = _spawn.transform.position;
        Vector2 bulletForce;
        float x = _spawn.transform.position.x - transform.position.x;
        float y = _spawn.transform.position.y - transform.position.y;
        bulletForce = new Vector2(x, y);
        GameObject bulletClone = Instantiate(_bullet, 
            bulletPosition, 
            transform.rotation) as GameObject;
        bulletClone.GetComponent<Rigidbody2D>().velocity = bulletForce * _speed;
    }

    private void PlayMusic()
    {
        GetComponent<AudioSource>().PlayOneShot(_shoot);
    }
}