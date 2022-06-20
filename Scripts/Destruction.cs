using UnityEngine;

public class Destruction : MonoBehaviour
{
    public void EffectDestroys(GameObject explosion)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}