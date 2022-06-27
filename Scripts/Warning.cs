using UnityEngine;

public class Warning : MonoBehaviour
{
    [SerializeField] private GameObject _warningReturn;
    [SerializeField] private GameObject _warningExit;

    public void ReturnAppear()
    {
        _warningReturn.SetActive(true);
    }

    public void ExitAppear()
    {
        _warningExit.SetActive(true);
    }

    public void Disappear()
    {
        _warningReturn.SetActive(false);
        _warningExit.SetActive(false);
    }
}