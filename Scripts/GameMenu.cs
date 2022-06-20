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

    private bool _playSong = false;

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
        PlayMusic();
        _playSong = true;
    }

    private void OnRestartButtonClick()
    {
        PlayMusic();

        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClick()
    {
        PlayMusic();

        _warning.SetActive(true);
    }

    private void OnReturnMenuButtonClick()
    {
        PlayMusic();

        SceneManager.LoadScene(0);
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