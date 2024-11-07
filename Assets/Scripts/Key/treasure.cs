using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasure : MonoBehaviour
{
    public static treasure instance;
    public bool getkey;

    [SerializeField]
    private SpriteRenderer beforeRenderer;

    [SerializeField]
    private Sprite afterSprite;

    private void Awake()
    {
        instance = this;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (getkey == false)
            {
                beforeRenderer.sprite = afterSprite;
                getkey = true;
            }
        }
    }

}