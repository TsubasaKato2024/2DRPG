using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cameraMoveDuration = 10f;  // カメラ移動にかかる時間
    public float targetYPosition = 2f;   // カメラが止まるy座標
    public float startYPosition = 18f;     // カメラの初期位置

    private bool isMoving = true;          // カメラの移動を制御するフラグ
    private float elapsedTime = 0f;        // 経過時間
    private Vector3 startPosition;         // カメラの開始位置
    private Vector3 targetPosition;        // カメラの最終位置

    private void Start()
    {
        // カメラの初期位置と最終位置を設定
        startPosition = new Vector3(Camera.main.transform.position.x, startYPosition, Camera.main.transform.position.z);
        targetPosition = new Vector3(Camera.main.transform.position.x, targetYPosition, Camera.main.transform.position.z);

        // 初期位置にカメラをセット
        Camera.main.transform.position = startPosition;
    }

    private void Update()
    {
        if (isMoving)
        {
            // カメラを上から下に移動させる
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / cameraMoveDuration;

            // カメラの位置をLerpで補間
            Camera.main.transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            // カメラがターゲット位置に達したら移動を停止
            if (Camera.main.transform.position.y <= targetPosition.y)
            {
                Camera.main.transform.position = targetPosition;  // 最終位置を設定
                isMoving = false;  // 移動を停止
            }
        }
    }
}