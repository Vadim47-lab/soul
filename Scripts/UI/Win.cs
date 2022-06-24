using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] private Warning _warning;
    [SerializeField] private Present _present;
    [SerializeField] private Press _press;
    [SerializeField] private Fon _fon;
    [SerializeField] private Toy _toy;
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
        _warning.WarningExitBecomeTrue();
    }

    private void OnMainMenuButtonClick()
    {
        PlayMusic();
        SceneManager.LoadScene(0);
    }

    private void OnPresentButtonClick()
    {
        PlayMusic();
        _present.GameObjectDisappears();
        _toy.GameObjectDisappears();
    }

    public void PressNo()
    {
        PlayMusic();
        _warning.WarningBecomeFalse();
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
            _press.PlayButtonPress();
        }

        if (_playSong == false)
        {
            _fon.PlayFonMusic();
        }
    }
}