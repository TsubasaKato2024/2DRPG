using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1f; // 攻撃範囲
    public int attackDamage = 10; // 攻撃ダメージ
    public LayerMask BossLayer; // 攻撃対象となるレイヤー
    public Vector2 attackOffset = new Vector2(0.5f, 0.5f); // 攻撃範囲のオフセット
    public GameObject hitEffectPrefab; // ヒットエフェクトのプレハブ
    public GameObject weapon;       // 武器オブジェクト
    public Transform handPosition;  // プレイヤーの手の位置を示すTransform

    private Animator animator;

    void Start()
    {
        weapon = transform.Find("Weapon").gameObject;  // プレイヤーの子オブジェクトから武器を取得
        //weapon.transform.SetParent(handPosition);  // 武器を手の位置の子オブジェクトに設定
        //weapon.transform.localPosition = Vector3.zero;  // 手の位置に合わせて武器を配置
        //weapon.transform.localRotation = Quaternion.identity;  // 手の回転に合わせる
    }

    void Update()
    {
        weapon.transform.position = handPosition.position;  // 手の位置に武器を配置
        weapon.transform.rotation = handPosition.rotation;  // 手の回転に合わせて武器を回転

        if (Input.GetButtonDown("Fire1")) // 攻撃ボタンを押したとき
        {
            Attack();

        }
    }

    void Attack()
    {
        // 攻撃範囲をずらした位置で敵を検出
        Vector2 attackPosition = (Vector2)transform.position + attackOffset; // 攻撃位置をずらす
        Collider2D[] hitBoss = Physics2D.OverlapCircleAll(attackPosition, attackRange, BossLayer);

        foreach (Collider2D enemy in hitBoss)
        {
            // ヒットエフェクトを表示
            Instantiate(hitEffectPrefab, enemy.transform.position, Quaternion.identity);

            // ボスにダメージを与える
            enemy.GetComponent<BossHealth>().TakeDamage(attackDamage);
        }

        // 攻撃アニメーションの再生など
        // Animatorを使う場合はアニメーションを再生するコードをここに追加
    }

    // 攻撃範囲を視覚的に表示（デバッグ用）
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        // 攻撃範囲をずらした位置に表示
        Gizmos.DrawWireSphere((Vector2)transform.position + attackOffset, attackRange);
    }
}
