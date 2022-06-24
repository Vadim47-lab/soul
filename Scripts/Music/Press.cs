using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Press : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonPress;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonPress()
    {
        _audioSource.PlayOneShot(_buttonPress);
    }
}