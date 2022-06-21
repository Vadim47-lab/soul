using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip _shoot;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject _spawn;
    [SerializeField] private Transform _lifeBar;
    [SerializeField] private EnemyDisplay _enemyDisplay;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Cartridge _cartridge;
    [SerializeField] private Enemy _enemy;

    [SerializeField] private float _speed;
    [SerializeField] private int _hp;
    [SerializeField] private float _rof;
    [SerializeField] private float _random;
    [SerializeField] private int _countEnemy;

    private int _score;
    private float _time;
    private float _oldLifeBar;
    private readonly float _x = 1.75f;

    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        if (SceneManager.sceneCount == 1)
        {
            _countEnemy = 8;
        }

        else if (SceneManager.sceneCount == 2)
        {
            _countEnemy = 24;
        }

        _enemyDisplay.ShowAmountEnemy(_countEnemy);
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
            _cartridge.GenerateBullet(_effect, _spawn, _bullet, _speed);
            PlayMusic();

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
        _healthBar.ChangedHealthBar(_x, _lifeBar, _oldLifeBar, _hp);

        if (_hp <= 0)
        {
            Instantiate(_explosion, transform.position, transform.rotation);
            SceneManager.LoadScene(4);
        }
    }

    public void DefeatedEnemy()
    {
        if (_score == _countEnemy && SceneManager.sceneCount == 1)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void PlayMusic()
    {
        GetComponent<AudioSource>().PlayOneShot(_shoot);
    }
}