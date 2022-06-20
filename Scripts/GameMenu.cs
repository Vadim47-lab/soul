using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameMenu: MonoBehaviour
{
    [SerializeField] private AudioClip _buttonPress;
    [SerializeField] private AudioClip _music;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _returnButton;
    [SerializeField] private GameObject _warning;

    private bool _song1 = false;
    private bool _song2 = false;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _returnButton.onClick.AddListener(OnReturnMenuButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _returnButton.onClick.RemoveListener(OnReturnMenuButtonClick);
    }

    private void Start()
    {
        _song2 = true;
        PlayMusic();
        _song2 = false;
    }

    private void OnRestartButtonClick()
    {
        _song1 = true;
        PlayMusic();

        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        _song1 = false;
    }

    private void OnExitButtonClick()
    {
        _song1 = true;
        PlayMusic();

        _warning.SetActive(true);
        _song1 = false;
    }

    private void OnReturnMenuButtonClick()
    {
        _song1 = true;
        PlayMusic();

        SceneManager.LoadScene(0);
        _song1 = false;
    }

    public void PressNo()
    {
        _song1 = true;
        PlayMusic();
        _warning.SetActive(false);
        _song1 = false;
    }

    public void PressYesExit()
    {
        _song1 = true;
        PlayMusic();
        Application.Quit();
    }

    private void PlayMusic()
    {
        if (_song1 == true && _song2 == false)
        {
            GetComponent<AudioSource>().PlayOneShot(_buttonPress);
        }

        if (_song2 == true && _song1 == false)
        {
            GetComponent<AudioSource>().PlayOneShot(_music);
        }
    }
}