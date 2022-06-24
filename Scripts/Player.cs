using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Hit _hit;
    [SerializeField] private int _health;

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 objectPos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);
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

        _weapon.Shoot();
    }

    public void TakeDamage(int damage)
    {
        _hit.PlayHit();
        _health -= damage;
        _healthBar.ChangedHealthBar(_health);

        if (_health <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }
}