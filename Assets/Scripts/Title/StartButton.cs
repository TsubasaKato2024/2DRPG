using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    public AudioClip soundEffect; // 効果音用のオーディオ
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSourceコンポーネントを取得
        var button = GetComponent<Button>();

        // ボタンがクリックされたときにStartGameメソッドを呼び出す
        button.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        // 効果音を再生
        if (soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }
        else
        {
            Debug.LogWarning("効果音が設定されていません！"); // 警告メッセージ
        }

        // シーンを切り替える
        SceneManager.LoadScene("EpisodeScene");
    }
}