using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Press _press;
    [SerializeField] private Warning _warning;
    [SerializeField] private GameObject _menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void OpenMenu()
    {
        _press.PlayButtonPress();
        Time.timeScale = 0;
        _menu.SetActive(true);
    }

    public void CloseMenu()
    {
        _press.PlayButtonPress();
        _menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void ReturnMenu()
    {
        _press.PlayButtonPress();
        _warning.WarningReturnBecomeTrue();
    }

    public void PressYesReturnMenu()
    {
        _press.PlayButtonPress();
        SceneManager.LoadScene(0);
    }

    public void PressYesExit()
    {
        _press.PlayButtonPress();
        Application.Quit();
    }

    public void PressNo()
    {
        _press.PlayButtonPress();
        _warning.WarningBecomeFalse();
    }

    public void Exit()
    {
        _press.PlayButtonPress();
        _warning.WarningExitBecomeTrue();
    }
}