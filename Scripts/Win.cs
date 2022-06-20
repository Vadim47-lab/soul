using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Win : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonPress;
    [SerializeField] private AudioClip _music;
    [SerializeField] private GameObject _present;
    [SerializeField] private GameObject _toy;
    [SerializeField] private GameObject _warning;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _presentButton;

    private bool _playSong = false;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
        _presentButton.onClick.AddListener(OnPresentButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClick);
        _presentButton.onClick.RemoveListener(OnPresentButtonClick);
    }

    private void Start()
    {
        PlayMusic();
        _playSong = true;
    }

    private void OnRestartButtonClick()
    {
        PlayMusic();

        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClick()
    {
        PlayMusic();

        _warning.SetActive(true);
    }

    private void OnMainMenuButtonClick()
    {
        PlayMusic();

        SceneManager.LoadScene(0);
    }

    private void OnPresentButtonClick()
    {
        PlayMusic();

        _present.SetActive(false);
        _toy.SetActive(true);
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
        if (_playSong == true)
        {
            GetComponent<AudioSource>().PlayOneShot(_buttonPress);
        }

        if (_playSong == false)
        {
            GetComponent<AudioSource>().PlayOneShot(_music);
        }
    }
}