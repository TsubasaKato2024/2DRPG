using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float verticalSpeed = 0.1f;  // カメラの上下移動速度
    public float horizontalSpeed = 0.02f;  // カメラの横移動速度
    public float horizontalRange = 0.5f;  // 横移動の範囲
    public float verticalRange = 0.3f;  // 上下移動の範囲

    private Vector3 initialPosition;  // 初期位置

    void Start()
    {
        initialPosition = transform.position;  // 初期位置を記録
    }

    void Update()
    {
        // カメラを上下に動かす（サイン波でスムーズに動く）
        float verticalMovement = Mathf.Sin(Time.time * verticalSpeed) * verticalRange;

        // カメラを横に揺らす（ランダムに動かす）
        float horizontalMovement = Mathf.Sin(Time.time * horizontalSpeed) * horizontalRange;

        // 新しい位置を計算
        Vector3 newPosition = initialPosition + new Vector3(horizontalMovement, verticalMovement, 0);

        // カメラの位置を更新
        transform.position = newPosition;
    }
}
