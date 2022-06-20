using UnityEngine;

public class Cartridge : MonoBehaviour
{
    public void GenerateBullet(GameObject effect, GameObject spawn, GameObject bullet, float speed)
    {
        GameObject eff = Instantiate(effect, spawn.transform.position, transform.rotation);
        eff.transform.SetParent(spawn.transform);
        Vector3 bulletPosition = spawn.transform.position;
        Vector2 bulletForce;
        float x = spawn.transform.position.x - transform.position.x;
        float y = spawn.transform.position.y - transform.position.y;
        bulletForce = new Vector2(x, y);
        GameObject bulletClone = Instantiate(bullet,
            bulletPosition,
            transform.rotation) as GameObject;
        bulletClone.GetComponent<Rigidbody2D>().velocity = bulletForce * speed;
    }
}