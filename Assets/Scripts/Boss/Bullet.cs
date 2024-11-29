using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;  // 弾の移動速度
    private Vector2 direction;  // 弾の移動方向

    // 弾の方向を設定
    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    void Update()
    {
        // 弾を移動
        transform.Translate(direction * speed * Time.deltaTime);

        // 画面外に出たら弾を削除する
        if (Mathf.Abs(transform.position.x) > 15f || Mathf.Abs(transform.position.y) > 15f)
        {
            Destroy(gameObject);
        }
    }
}
