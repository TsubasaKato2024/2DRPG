using UnityEngine;

public class SakuraPetal : MonoBehaviour
{
    public float floatSpeed = 0.5f;  // 花びらの浮遊速度
    public float rotationSpeed = 40f;  // 花びらの回転速度
    public float driftSpeed = 1f;  // 横の浮遊速度

    private Vector2 initialPosition;  // 花びらの初期位置

    void Start()
    {
        initialPosition = transform.position;  // 初期位置を保存
    }

    void Update()
    {
        // 花びらが舞う動きを追加
        transform.Translate(Vector2.up * floatSpeed * Time.deltaTime);  // 上に浮かぶ
        transform.Translate(Vector2.right * Mathf.Sin(Time.time) * driftSpeed * Time.deltaTime);  // 横に揺れる
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);  // 回転させる

        // 一定の範囲を超えたら初期位置に戻る
        if (transform.position.y > initialPosition.y + 5f)
        {
            ResetPetal();
        }
    }

    // 花びらが舞い終わったら位置をリセット
    void ResetPetal()
    {
        float randomX = Random.Range(-5f, 5f);
        float randomY = Random.Range(-2f, 2f);
        transform.position = new Vector2(randomX, randomY);
    }
}
