using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Shoot : MonoBehaviour
{
    [SerializeField] private AudioClip _soundShoot;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayShoot()
    {
        _audioSource.PlayOneShot(_soundShoot);
    }
}