using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - _player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = _player.transform.position + offset;
    }
}