using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider playerHPBar;  // プレイヤーのHPバー
    public Slider bossHPBar;    // ボスのHPバー

    // プレイヤーのHPとボスのHPを更新する関数
    public void UpdateHPBar(int playerHP, int bossHP)
    {
        playerHPBar.value = playerHP;  // プレイヤーのHPバーを更新
        bossHPBar.value = bossHP;      // ボスのHPバーを更新
    }
}
