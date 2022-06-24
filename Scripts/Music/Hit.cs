using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Hit : MonoBehaviour
{
    [SerializeField] private AudioClip _soundHit;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayHit()
    {
        _audioSource.PlayOneShot(_soundHit);
    }
}