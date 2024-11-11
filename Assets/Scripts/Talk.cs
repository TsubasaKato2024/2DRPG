using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    public GameObject dialogue;
    public Text Text;

    [SerializeField]
    string words = "おじいちゃんが勇者だった時 金魚の敵を倒した話";
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Text.text = words;
            dialogue.SetActive(true);
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