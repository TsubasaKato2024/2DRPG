using UnityEngine;

public class HPBarController : MonoBehaviour
{
    public GameObject player;  // プレイヤーキャラクター
    public GameObject hpBar;   // HPバー（Slider）

    public Vector3 offset = new Vector3(0f, 2f, 0f);  // HPバーの位置をキャラクターの上にオフセット

    void Update()
    {
        // プレイヤーの位置を取得して、HPバーの位置を更新
        Vector3 playerPosition = player.transform.position;
        hpBar.transform.position = playerPosition + offset;
    }
}
