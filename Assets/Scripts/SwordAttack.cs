using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour
{
    public float attackDistance = 2.5f;  // 突く距離
    public float attackDuration = 0.2f;  // 突くのにかかる時間
    public float returnDuration = 0.2f;  // 元の位置に戻るのにかかる時間
    public float rotationAngle = -60f;    // 回転角度
    private bool isAttacking = false;    // 攻撃中かどうか

    private Vector3 startPosition;  // 初期位置
    private float startRotation;    // 初期回転

    private Transform playerTransform; // プレイヤーのTransform

    void Start()
    {
        playerTransform = transform.parent; // プレイヤーを親オブジェクトとして設定
        startPosition = transform.localPosition;  // ローカル位置で初期位置を保存
        startRotation = transform.localRotation.eulerAngles.z;  // ローカル回転で初期回転を保存
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking) // 攻撃ボタン（例えば、左クリック）
        {
            StartCoroutine(PerformSwordAttack());
        }
    }

    // ソードを突きながら回転するコルーチン
    IEnumerator PerformSwordAttack()
    {
        isAttacking = true;

        // プレイヤーの前方に剣を移動させる
        Vector3 targetPosition = playerTransform.position + playerTransform.right * attackDistance; // プレイヤーの前方を基準に移動
        float targetRotation = startRotation + rotationAngle;  // 回転角度

        // 突きながら回転する
        float time = 0f;
        while (time < attackDuration)
        {
            time += Time.deltaTime;
            // 剣の位置を滑らかに移動
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition - playerTransform.position, time / attackDuration); // プレイヤー基準で移動
            // 剣の回転を滑らかに変更
            float rotationZ = Mathf.Lerp(startRotation, targetRotation, time / attackDuration);
            transform.localRotation = Quaternion.Euler(0, 0, rotationZ);
            yield return null;
        }

        // 最終的な位置と回転を正確に設定
        transform.localPosition = targetPosition - playerTransform.position;
        transform.localRotation = Quaternion.Euler(0, 0, targetRotation);

        // 元の位置と回転に戻す
        time = 0f;
        while (time < returnDuration)
        {
            time += Time.deltaTime;
            // 剣の位置を滑らかに戻す
            transform.localPosition = Vector3.Lerp(targetPosition - playerTransform.position, startPosition, time / returnDuration);
            // 剣の回転を滑らかに戻す
            float rotationZ = Mathf.Lerp(targetRotation, startRotation, time / returnDuration);
            transform.localRotation = Quaternion.Euler(0, 0, rotationZ);
            yield return null;
        }

        // 最終的な位置と回転を正確に設定
        transform.localPosition = startPosition;
        transform.localRotation = Quaternion.Euler(0, 0, startRotation);

        isAttacking = false;
    }
}
