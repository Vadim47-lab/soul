using UnityEngine;

public class Cartridge : MonoBehaviour
{
    public void GenerateBullet(GameObject effect, GameObject spawn, Bullet bullet, float speed)
    {
        GameObject eff = Instantiate(effect, spawn.transform.position, transform.rotation);
        eff.transform.SetParent(spawn.transform);
        Vector3 bulletPosition = spawn.transform.position;
        Vector2 bulletForce;
        float x = spawn.transform.position.x - transform.position.x;
        float y = spawn.transform.position.y - transform.position.y;
        bulletForce = new Vector2(x, y);
        Bullet bulletClone = Instantiate(bullet,
            bulletPosition,
            transform.rotation);
        bulletClone.TakeRigidbody2D.velocity = bulletForce * speed;
    }
}