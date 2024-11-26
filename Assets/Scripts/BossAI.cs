using UnityEngine;

public class BossAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 3f;
    public Transform player;
    private float attackCooldown = 1f;
    private float lastAttackTime = -1f;

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // プレイヤーに接近する
        if (distanceToPlayer > attackRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            // プレイヤーとの距離が近いときに攻撃
            if (Time.time - lastAttackTime > attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    }

    void AttackPlayer()
    {
        // プレイヤーへの攻撃処理
        Debug.Log("攻撃！");
    }
}
