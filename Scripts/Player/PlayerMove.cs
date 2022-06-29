using UnityEngine;

[RequireComponent(typeof(ObjectMove))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private ObjectMove _objectMove;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        _objectMove.Move(_rigidbody2D, _speed, moveX, moveY);
    }
}