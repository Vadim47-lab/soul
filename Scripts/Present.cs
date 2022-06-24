using UnityEngine;

public class Present : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectPresent;

    public void GameObjectDisappears()
    {
        _gameObjectPresent.SetActive(false);
    }
}