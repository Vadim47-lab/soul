using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            SceneManager.LoadScene(3);
        }
    }
}