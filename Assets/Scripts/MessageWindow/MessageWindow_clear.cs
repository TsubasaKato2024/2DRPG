using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // シーン管理用
using System.Collections;

public class MessageWindow_Clear : MonoBehaviour
{
    public Text messageText;  // メッセージテキスト
    private string currentMessage;  // 現在表示中のメッセージ

    void Start()
    {
        // メッセージの表示を開始
        ShowMessage("村は平和を取り戻し、" +
            "勇者は英雄として迎えられました。" +
            "　～　　T  H  E   E  N  D　　～　");
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
        foreach (char letter in currentMessage)
        {
            messageText.text += letter;
            yield return new WaitForSeconds(0.1f);  // 文字を表示する間隔
        }

        // メッセージが完了した後、シーン遷移を開始
        StartCoroutine(WaitAndLoadScene());
    }

    // 10秒待ってから次のシーンに遷移するコルーチン
    private IEnumerator WaitAndLoadScene()
    {
        // 10秒待機（メッセージが表示された後に次のシーンへ遷移）
        yield return new WaitForSeconds(5);

        // 次のシーンに遷移
        SceneManager.LoadScene("TitleScene");  // 次のシーン名を指定
    }
}