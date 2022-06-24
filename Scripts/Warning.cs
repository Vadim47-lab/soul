using UnityEngine;

public class Warning : MonoBehaviour
{
    [SerializeField] private GameObject _warningReturn;
    [SerializeField] private GameObject _warningExit;

    public void WarningReturnBecomeTrue()
    {
        _warningReturn.SetActive(true);
    }

    public void WarningExitBecomeTrue()
    {
        _warningExit.SetActive(true);
    }

    public void WarningBecomeFalse()
    {
        _warningReturn.SetActive(false);
        _warningExit.SetActive(false);
    }
}