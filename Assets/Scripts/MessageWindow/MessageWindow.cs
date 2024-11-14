using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // シーン管理用
using System.Collections;

public class MessageWindow : MonoBehaviour
{
    public Text messageText;  // メッセージテキスト
    public Button nextButton; // 次へボタン

    private string currentMessage;  // 現在表示中のメッセージ
    private bool isTyping = false;  // タイピング中かどうか

    void Start()
    {
        nextButton.onClick.AddListener(OnNextButtonClicked);
    }

    // メッセージを表示するメソッド
    public void ShowMessage(string message)
    {
        currentMessage = message;
        messageText.text = "";
        StartCoroutine(TypeMessage());
    }

    // メッセージを1文字ずつタイプするコルーチン
    private IEnumerator TypeMessage()
    {
        isTyping = true;

        foreach (char letter in currentMessage)
        {
            messageText.text += letter;
            yield return new WaitForSeconds(0.1f);  // 文字を表示する間隔
        }

        isTyping = false;
    }

    // 次へボタンが押されたとき
    private void OnNextButtonClicked()
    {
        if (!isTyping)
        {
            ShowMessage("おじいちゃんは目を覚ました。" +
                "昔、自分が勇者だった頃を思い出しながら・・・");

            // メッセージがすべて表示されたら、次のシーンに進むために遅延する
            StartCoroutine(WaitAndLoadScene());

            // ボタンを削除
            Destroy(nextButton.gameObject);
        }
    }

    // 10秒待ってから次のシーンに遷移するコルーチン
    private IEnumerator WaitAndLoadScene()
    {
        // 10秒待機
        yield return new WaitForSeconds(10);

        // 次のシーンに遷移
        SceneManager.LoadScene("FirstScene");  // 次のシーン名を指定
    }
}