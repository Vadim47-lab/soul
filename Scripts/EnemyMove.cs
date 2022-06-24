using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private int _speed;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(Move), 1, 1);
    }

    public void Move()
    {
        var x = Random.Range(-_speed, _speed);
        var y = Random.Range(-_speed, _speed);

        _rigidbody2D.AddForce(new Vector2(x, y) * _speed, ForceMode2D.Force);
    }
}