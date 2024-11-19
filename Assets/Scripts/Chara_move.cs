using UnityEngine;

public class Chara_move : MonoBehaviour
{
    public float speed = 3f; //floatは小数点
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    Vector2 pos = Vector2.zero;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        pos = Vector2.zero;

        if (Input.GetKey(KeyCode.S))//↓キーを押したら
        {
            pos.y = -speed;
            animator.SetInteger("direction", 0);//正面を向く
        }
        else if (Input.GetKey(KeyCode.A))//←キーを押したら
        {

            pos.x = -speed;
            animator.SetInteger("direction", 1);//左を向く
        }
        else if (Input.GetKey(KeyCode.D))//→キーを押したら
        {
            pos.x = speed;
            animator.SetInteger("direction", 2);//右を向く

        }
        else if (Input.GetKey(KeyCode.W))//↑キーを押したら
        {
            pos.y = speed;
            animator.SetInteger("direction", 3);//後ろを向く
        }

    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = pos;
    }
}