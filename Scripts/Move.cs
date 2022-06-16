using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        rb.AddForce(new Vector2(moveX * _speed, moveY * _speed), ForceMode2D.Force);
    }
}