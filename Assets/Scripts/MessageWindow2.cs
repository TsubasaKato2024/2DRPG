using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // シーン管理用
using System.Collections;

public class MessageWindow2 : MonoBehaviour
{
    public Text messageText;  // メッセージテキスト
    private string currentMessage;  // 現在表示中のメッセージ

    void Start()
    {
        // メッセージの表示を開始
        ShowMessage("昔々 村の池には金魚たちが住み" +
            "村を守る神として大切にされていました。" +
            "勇者は金魚たちと特別な絆を結んでいましたが" +
            "ある日 池に黒い霧が立ち込め 巨大な金魚「黒鯉」が復活します。" +
            "黒鯉は村を滅ぼそうとし 勇者は祖父から受け継いだ神剣を手に 立ち向かう決意を固めます。");
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
        yield return new WaitForSeconds(10);

        // 次のシーンに遷移
        SceneManager.LoadScene("SecondScene");  // 次のシーン名を指定
    }
}