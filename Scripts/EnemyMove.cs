using UnityEngine;

[RequireComponent(typeof(ObjectMove))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private ObjectMove _objectMove;
    [SerializeField] private float _speed;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(Move), 1, 1);
    }

    public void Move()
    {
        float x = Random.Range(-_speed, _speed);
        float y = Random.Range(-_speed, _speed);

        _objectMove.Move(_rigidbody2D, _speed, x, y);
    }
}