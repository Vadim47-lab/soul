using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private int _time;

    private void Start()
    {
        Destroy(gameObject, _time);
    }
}