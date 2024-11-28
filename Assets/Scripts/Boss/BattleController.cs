using UnityEngine;

public enum BattleState { PLAYER_TURN, BOSS_TURN, GAME_OVER, WIN }
public class BattleController : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public float battleDistance = 5f;  // 戦闘の開始距離
    public BattleState currentState;

    void Start()
    {
        currentState = BattleState.PLAYER_TURN; // 戦闘開始時はプレイヤーのターン
    }

    void Update()
    {
        switch (currentState)
        {
            case BattleState.PLAYER_TURN:
                PlayerTurn();
                break;
            case BattleState.BOSS_TURN:
                BossTurn();
                break;
            case BattleState.GAME_OVER:
                GameOver();
                break;
            case BattleState.WIN:
                Win();
                break;
        }
    }

    void PlayerTurn()
    {
        // プレイヤーが攻撃を選択した時の処理
        if (Input.GetButtonDown("Fire1")) // 攻撃ボタン
        {
            AttackBoss();
            currentState = BattleState.BOSS_TURN; // ボスのターンに切り替え
        }
    }

    void BossTurn()
    {
        // ボスが攻撃する処理
        // ボスの攻撃アニメーションやダメージ計算
        currentState = BattleState.PLAYER_TURN; // プレイヤーのターンに戻す
    }

    void AttackBoss()
    {
        // プレイヤーがボスにダメージを与える処理
        Debug.Log("プレイヤーがボスを攻撃！");
        // ボスのHPを減らすなど
    }

    void GameOver()
    {
        // プレイヤーのHPが0になったときの処理
        Debug.Log("ゲームオーバー");
    }

    void Win()
    {
        // ボスを倒した時の処理
        Debug.Log("ボスを倒した！");
    }
}
