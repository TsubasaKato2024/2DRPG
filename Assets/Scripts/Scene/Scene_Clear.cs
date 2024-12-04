using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Clear : MonoBehaviour
{
    public GameObject dialogue;
    public Text Text;

    [SerializeField]
    string words = "";
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Text.text = words;
            dialogue.SetActive(true);
            StartCoroutine(WaitAndChangeScene(1f)); // 1.5秒後にシーン遷移
        }
    }

    // コルーチンで指定された時間（秒数）後にシーン遷移
    private IEnumerator WaitAndChangeScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); // 1.5秒待つ
        SceneManager.LoadScene("QuizScene"); // シーン遷移
    }
}