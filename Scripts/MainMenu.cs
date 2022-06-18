using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonPress;
    [SerializeField] private AudioClip _music;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _warning;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Start()
    {
        PlayMusic2();
    }

    private void OnStartButtonClick()
    {
        PlayMusic();
        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClick()
    {
        PlayMusic();
        _warning.SetActive(true);
    }

    public void PressNo()
    {
        PlayMusic();
        _warning.SetActive(false);
    }

    public void PressYesExit()
    {
        PlayMusic();
        Application.Quit();
    }

    private void PlayMusic()
    {
        GetComponent<AudioSource>().PlayOneShot(_buttonPress);
    }

    private void PlayMusic2()
    {
        GetComponent<AudioSource>().PlayOneShot(_music);
    }
}