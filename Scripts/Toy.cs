using UnityEngine;

public class Toy : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectToy;

    public void GameObjectDisappears()
    {
        _gameObjectToy.SetActive(true);
    }
}