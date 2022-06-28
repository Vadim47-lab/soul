using UnityEngine;
using static UnityEngine.ParticleSystem;

public class DestructionObject : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private GameObject _killEffect;

    public void HitEffect()
    {
        Instantiate(_hitEffect, transform.position, transform.rotation);
        DestroyGameObject();
    }

    public void KillEffect()
    {
        Instantiate(_killEffect, transform.position, transform.rotation);
        DestroyGameObject();
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}