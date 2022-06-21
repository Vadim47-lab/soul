using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Menu : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonPress;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _warning1;
    [SerializeField] private GameObject _warning2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1;
    }

    public void OpenMenu()
    {
        PlayMusic();
        Time.timeScale = 0;
        _menu.SetActive(true);
    }

    public void CloseMenu()
    {
        PlayMusic();
        _menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void ReturnMenu()
    {
        PlayMusic();
        _warning1.SetActive(true);
        _warning2.SetActive(false);
    }

    public void PressYesReturnMenu()
    {
        PlayMusic();
        SceneManager.LoadScene(0);
    }

    public void PressYesExit()
    {
        PlayMusic();
        Application.Quit();
    }

    public void PressNo()
    {
        PlayMusic();
        _warning1.SetActive(false);
        _warning2.SetActive(false);
    }

    public void Exit()
    {
        PlayMusic();
        _warning2.SetActive(true);
        _warning1.SetActive(false);
    }

    private void PlayMusic()
    {
        _audioSource.PlayOneShot(_buttonPress);
    }
}