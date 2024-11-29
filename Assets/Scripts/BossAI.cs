using UnityEngine;

public class BossAI : MonoBehaviour
{
    public float moveSpeed = 2f;         // 移動速度
    public float yMoveAmplitude = 0.5f;  // y方向の小刻みな移動の振幅
    public float yMoveSpeed = 1f;        // y方向の移動スピード（上下の動きの速さ）
    public float attackRange = 5f;       // 弾の射程範囲
    public float attackCooldown = 1f;    // 弾を撃つ間隔
    public float randomMoveInterval = 3f; // ランダムで移動方向を変えるインターバル
    public Transform player;             // プレイヤーの位置
    public GameObject bulletPrefab;      // 弾のプレハブ

    private float lastAttackTime = -1f;  // 最後の攻撃時間
    private float lastMoveChangeTime = 0f; // 最後に移動方向を変えた時間
    private float startYPosition;        // ボスの初期位置（y座標）
    private float randomMoveDirection = 1f; // ランダム移動方向（1:上、-1:下）

    void Start()
    {
        // ボスの初期位置（y座標）を記録
        startYPosition = transform.position.y;
    }

    void Update()
    {
        // 斜め移動（ランダム方向の上下移動）
        MoveDiagonally();

        // プレイヤーとの距離が攻撃範囲以内であれば弾を撃つ
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange && Time.time - lastAttackTime > attackCooldown)
        {
            AttackPlayer();
            lastAttackTime = Time.time;
        }

        // ランダムに移動方向を変える
        if (Time.time - lastMoveChangeTime > randomMoveInterval)
        {
            ChangeRandomMoveDirection();
            lastMoveChangeTime = Time.time;
        }
    }

    // 斜め移動（ランダム方向の上下動き）
    void MoveDiagonally()
    {
        // サイン波を使ってy方向に小刻みに動く
        float yOffset = Mathf.Sin(Time.time * yMoveSpeed) * yMoveAmplitude * randomMoveDirection;

        // 斜め移動を実現するためにx方向とy方向に移動
        float xMove = Mathf.Cos(Time.time * moveSpeed) * moveSpeed; // 斜め方向にx方向移動
        float yMove = yOffset;  // 上下方向に小刻み動く

        // ボスの位置を更新
        transform.position = new Vector3(transform.position.x + xMove * Time.deltaTime, startYPosition + yMove, transform.position.z);
    }

    // ランダムに移動方向を変更
    void ChangeRandomMoveDirection()
    {
        randomMoveDirection = Random.Range(-1f, 1f) > 0 ? 1f : -1f;  // ランダムで上(1)か下(-1)に変わる
    }

    // プレイヤーに向かって弾を撃つ
    void AttackPlayer()
    {
        // プレイヤーの位置に向かって弾を発射
        Vector2 directionToPlayer = (player.position - transform.position).normalized;

        // 弾を発射
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // 弾に移動方向を設定
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(directionToPlayer); // 弾の方向を設定
        }

        Debug.Log("弾を発射！");
    }
}
