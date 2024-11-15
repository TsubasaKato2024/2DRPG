using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Third_2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Third2Scene");
        }
    }

}

