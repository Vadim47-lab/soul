using UnityEngine;

public class Warning : MonoBehaviour
{
    [SerializeField] private GameObject _warningReturn;
    [SerializeField] private GameObject _warningExit;

    public void ReturnBecomeTrue()
    {
        _warningReturn.SetActive(true);
    }

    public void ExitBecomeTrue()
    {
        _warningExit.SetActive(true);
    }

    public void BecomeFalse()
    {
        _warningReturn.SetActive(false);
        _warningExit.SetActive(false);
    }
}