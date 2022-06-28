using UnityEngine;

[RequireComponent(typeof(ObjectMove))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private ObjectMove _objectMove;
    [SerializeField] private float _speed;

    private float _time;
    private float _repeatRate;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _time = 1;
        _repeatRate = 1;
        InvokeRepeating(nameof(Move), _time, _repeatRate);
    }

    public void Move()
    {
        float x = Random.Range(-_speed, _speed);
        float y = Random.Range(-_speed, _speed);

        _objectMove.Move(_rigidbody2D, _speed, x, y);
    }
}