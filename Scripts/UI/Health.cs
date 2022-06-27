using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Transform _lifeBar;
    [SerializeField] private HealthBar _healthBar;

    private float _oldLifeBar;
    private readonly float _axisX = 1.75f;

    private void OnEnable()
    {
        _healthBar.HealthBarChanged += OnHealhChanged;
    }

    private void OnDisable()
    {
        _healthBar.HealthBarChanged -= OnHealhChanged;
    }

    private void Start()
    {
        _oldLifeBar = _lifeBar.localScale.x;
    }

    public void OnHealhChanged(int health)
    {
        _lifeBar.localPosition = new Vector2(_axisX * health / 100 - _axisX, _lifeBar.localPosition.y);
        _lifeBar.localScale = new Vector2(_oldLifeBar * health / 100, _lifeBar.localScale.y);
    }
}