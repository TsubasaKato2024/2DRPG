using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button[] buttons; // ボタンの配列
    public AudioSource audioSource; // AudioSourceの参照
    public AudioClip selectSound; // 効果音のAudioClip

    private int selectedButtonIndex = 0;

    void Start()
    {
        // スタートボタンに焦点を合わせる
        EventSystem.current.SetSelectedGameObject(buttons[selectedButtonIndex].gameObject);
        UpdateButtonSelection();
    }

    void Update()
    {
        // 上矢印キーで選択を上に移動
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedButtonIndex--;
            if (selectedButtonIndex < 0) selectedButtonIndex = buttons.Length - 1;
            UpdateButtonSelection();
        }

        // 下矢印キーで選択を下に移動
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedButtonIndex++;
            if (selectedButtonIndex >= buttons.Length) selectedButtonIndex = 0;
            UpdateButtonSelection();
        }

        // Enterキーでボタンを押す
        if (Input.GetKeyDown(KeyCode.Return))
        {
            buttons[selectedButtonIndex].onClick.Invoke();
            PlaySelectSound(); // 効果音を再生
        }
    }

    private void UpdateButtonSelection()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }

        buttons[selectedButtonIndex].Select();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("FirstScene");
    }

    public void ShowControls()
    {
        SceneManager.LoadScene("ControlScene");
    }

    public void QuitGame()
    {
        PlaySelectSound(); // 効果音を再生
        Application.Quit();
    }

    private void PlaySelectSound()
    {
        if (audioSource != null && selectSound != null)
        {
            audioSource.PlayOneShot(selectSound); // 効果音を再生
        }
    }
}