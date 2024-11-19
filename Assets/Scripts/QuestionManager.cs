using UnityEngine;
using UnityEngine.SceneManagement;  // シーン遷移に必要

public class QuestionManager : MonoBehaviour
{
    public TMPro.TMP_Text questionText;  // TextMesh Proのテキスト
    public string question = "ゲームをクリアしますか？";  // 表示する質問
    public string nextSceneName = "ClearScene";  // クリアシーンの名前

    void Start()
    {
        // 初期質問をテキストに設定
        questionText.text = question;
    }

    // ボタンが押された時に呼ばれるメソッド
    public void OnNextButtonPressed()
    {
        // クリアシーンに遷移
        SceneManager.LoadScene(nextSceneName);
    }
}