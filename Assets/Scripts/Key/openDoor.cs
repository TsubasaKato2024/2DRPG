using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openDoor : MonoBehaviour
{
    public GameObject dialogue;
    public Text Text;

    [SerializeField]
    string words = "";
    private void OnCollisionEnter2D(Collision2D other)// オブジェクトが質量のあるものに触れたら
    {

        if (other.gameObject.CompareTag("Player"))// 中でもプレイヤーに触れたら
        {
            Text.text = words;
            dialogue.SetActive(true);

            if (treasure.instance.getkey == true)// 鍵を持っていたら    
            {
                dialogue.SetActive(false);
                gameObject.SetActive(false);// 扉を削除
            }
            else if (treasure.instance.getkey == false) // 鍵持ってなかったら
            {
                gameObject.SetActive (true);// 扉あり
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogue.SetActive(false);
        }
    }
}
