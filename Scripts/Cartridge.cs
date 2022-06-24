using UnityEngine;

public class Cartridge : MonoBehaviour
{
    public void GenerateBullet(GameObject effect, GameObject spawn, Bullet bullet, float speed)
    {
        GameObject eff = Instantiate(effect, spawn.transform.position, transform.rotation);
        eff.transform.SetParent(spawn.transform);
        Vector3 bulletPosition = spawn.transform.position;
        Vector2 bulletForce;
        bulletForce = spawn.transform.position - transform.position;
        Bullet bulletClone = Instantiate(bullet,
            bulletPosition,
            transform.rotation);
        bulletClone.GetNewComponent.velocity = bulletForce * speed;
    }
}