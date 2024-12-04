using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    public Button myButton;  // UIのButton
    public Text gameOverText;  // ゲームオーバーのテキスト
    public float waitTime = 4f;  // ボタンが表示されるまでの待機時間
    public float blinkInterval = 0.8f;  // 点滅の間隔

    void Start()
    {
        // ゲームオーバーのテキストを最初にアクティブにする
        gameOverText.gameObject.SetActive(true);  // 最初はアクティブにしておく

        // コルーチンを開始して点滅させる
        StartCoroutine(BlinkText());

        // ボタンは最初非表示
        myButton.gameObject.SetActive(false);

        // コルーチンを開始して、指定された時間後にボタンを表示する
        StartCoroutine(ShowButtonAfterDelay());
    }

    // 指定された時間待機した後にボタンを表示するコルーチン
    IEnumerator ShowButtonAfterDelay()
    {
        yield return new WaitForSeconds(waitTime);
        myButton.gameObject.SetActive(true);  // ボタンを表示

        // ボタンが押された時のイベントを設定
        myButton.onClick.AddListener(OnButtonClicked);
    }

    // ゲームオーバーのテキストを点滅させるコルーチン
    IEnumerator BlinkText()
    {
        while (true)  // 永遠に点滅し続ける
        {
            gameOverText.gameObject.SetActive(!gameOverText.gameObject.activeSelf);  // テキストを表示/非表示を切り替え
            yield return new WaitForSeconds(blinkInterval);  // 点滅の間隔を待機
        }
    }

    // ボタンがクリックされた時の処理
    void OnButtonClicked()
    {
        // シーン「4Scene」に遷移
        SceneManager.LoadScene("FifthScene");
    }
}
