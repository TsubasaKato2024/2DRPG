using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)// オブジェクトが質量のあるものに触れたら
    {

        if (other.gameObject.CompareTag("Player"))// 中でもプレイヤーに触れたら
        {
            if (treasure.instance.getkey == true)// 鍵を持っていたら
            {
                gameObject.SetActive(false);// 扉を削除
            }
        }
    }
}
