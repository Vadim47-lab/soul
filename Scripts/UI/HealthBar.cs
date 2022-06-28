using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform _lifeBar;
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    private float _oldLifeBar;
    private readonly float _axisX = 1.75f;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealhBarChanged;
        _enemy.HealthChanged += OnHealhBarChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealhBarChanged;
        _enemy.HealthChanged -= OnHealhBarChanged;
    }

    private void Start()
    {
        _oldLifeBar = _lifeBar.localScale.x;
    }

    public void OnHealhBarChanged(int health)
    {
        _lifeBar.localPosition = new Vector2(_axisX * health / 100 - _axisX, _lifeBar.localPosition.y);
        _lifeBar.localScale = new Vector2(_oldLifeBar * health / 100, _lifeBar.localScale.y);
    }
}