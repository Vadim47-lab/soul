using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public void Move(Rigidbody2D rigidbody2D, float speed, float moveX, float moveY)
    {
        rigidbody2D.AddForce(new Vector2(moveX * speed, moveY * speed), ForceMode2D.Force);
    }
}