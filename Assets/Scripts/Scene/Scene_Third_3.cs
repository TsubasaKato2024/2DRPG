using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Third_3 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Third3Scene");
        }
    }

}

