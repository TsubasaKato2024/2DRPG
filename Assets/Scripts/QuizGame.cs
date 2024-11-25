using UnityEngine;
using UnityEngine.UI;

public class QuizGame : MonoBehaviour
{
    // UIコンポーネント
    public Text questionText;             // 質問表示用のテキスト
    public Button[] answerButtons;        // 選択肢ボタン
    public Text resultText;               // ゲーム結果の表示用
    public Text timerText;                // カウントダウンタイマー表示用
    public Image backgroundImage;         // 背景の画像（点滅効果用）

    // 質問、選択肢、正解のデータ
    private string[] questions = { "勇者の一番最初のマップは石の家とレンガの家と3つめの家は何？", "鍵があった建物の名前はどれ？", "渡ってきた橋の名前はどれ？" };
    private string[][] answers = {
        new string[] { "赤の家", "黄の家", "青の家", "黒の家" },
        new string[] { "月影庵（つきかげあん）", "風雅楼（ふうがろう）", "雅の蔵 (みやびのくら)", "桜陰の邸 (さくらかげのてい)" },
        new string[] { "白鷺橋 (しらさぎばし)", "霧月橋 (きりつきばし)", "風雅橋 (ふうがばし)", "桜ノ瀬橋 (さくらのせばし)" }
    };
    private int[] correctAnswers = { 2, 0, 1 };  // 正解のインデックス（0から始まる）

    private int currentQuestionIndex = 0;  // 現在の質問インデックス
    private bool gameOver = false;         // ゲームオーバー判定
    private float timer = 10f;             // 各質問の制限時間（秒）
    private bool isFlashing = false;      // 点滅しているかどうかのフラグ
    private float flashInterval = 0.5f;   // 点滅のインターバル
    private float flashTimer = 0f;       // 点滅のタイマー

    // ゲーム開始時
    void Start()
    {
        resultText.text = "";
        timerText.text = timer.ToString("F1"); // 最初のタイマーを表示
        ShowQuestion();
        if (backgroundImage == null)
        {
            Debug.LogWarning("No background image assigned for flashing effect!");
        }
    }

    // 毎フレーム呼ばれるメソッド
    void Update()
    {
        if (gameOver) return;

        // タイマーの更新
        timer -= Time.deltaTime;  // 時間を減らす
        timerText.text = Mathf.Max(timer, 0).ToString("F1");  // タイマーが0未満にならないように設定

        // 点滅効果を始める
        if (timer <= 5f && !isFlashing)
        {
            isFlashing = true;  // 点滅を開始
        }

        // 点滅の処理
        if (isFlashing)
        {
            flashTimer += Time.deltaTime;

            if (flashTimer >= flashInterval)
            {
                // 背景色を切り替え
                if (backgroundImage != null)
                {
                    backgroundImage.enabled = !backgroundImage.enabled;
                }
                flashTimer = 0f;  // タイマーをリセット
            }
        }

        // タイマーが0になったらゲームオーバー
        if (timer <= 0)
        {
            GameOver("Time's up!");  // 時間切れでゲームオーバー
        }
    }

    // 質問を表示する
    void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex];
            timer = 10f;  // タイマーをリセット

            // 選択肢ボタンに答えを設定
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<Text>().text = answers[currentQuestionIndex][i];
                int index = i;  // ローカル変数を使ってボタンのクリックイベントにアクセス
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
            }
        }
    }

    // 答えが正しいかをチェック
    void CheckAnswer(int selectedIndex)
    {
        if (gameOver) return;

        // 正解をチェック
        if (selectedIndex == correctAnswers[currentQuestionIndex])
        {
            currentQuestionIndex++;  // 次の質問へ進む

            if (currentQuestionIndex == questions.Length)
            {
                // 全問正解した場合
                GameOver("You Win!");  // ゲームクリア
            }
            else
            {
                ShowQuestion();  // 次の質問を表示
            }
        }
        else
        {
            // 一度でも間違えるとゲームオーバー
            GameOver("Game Over!");  // ゲームオーバー
        }
    }

    // ゲームオーバーの処理
    void GameOver(string message)
    {
        gameOver = true;  // ゲームオーバー状態にする
        resultText.text = message;  // 結果メッセージを表示
        timerText.text = "";  // タイマーを消す
        isFlashing = false;  // 点滅を停止
        if (backgroundImage != null)
        {
            backgroundImage.enabled = true;  // 背景を元に戻す
        }
    }
}
