using UnityEngine;

public class Toy : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectToy;

    public void GameObjectAppearance()
    {
        _gameObjectToy.SetActive(true);
    }
}