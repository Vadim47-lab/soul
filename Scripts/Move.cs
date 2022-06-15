using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        rb.AddForce(new Vector2(moveX * speed, moveY * speed), ForceMode2D.Force);
    }
}