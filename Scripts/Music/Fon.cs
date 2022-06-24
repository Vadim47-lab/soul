using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Fon : MonoBehaviour
{
    [SerializeField] private AudioClip _fonMusic;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayFonMusic()
    {
        _audioSource.PlayOneShot(_fonMusic);
    }
}