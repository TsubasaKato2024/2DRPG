using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private void Start()
    {
        var button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            // アプリケーションを終了する
            Application.Quit();

            // エディタで実行中の場合、エディタを停止する（デバッグ用）
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        });
    }
}