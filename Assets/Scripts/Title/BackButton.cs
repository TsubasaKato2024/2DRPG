using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public AudioSource audioSource; // AudioSourceの参照
    public AudioClip selectSound; // 効果音のAudioClip

    private void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        PlaySelectSound(); // 効果音を再生
        SceneManager.LoadScene("TitleScene");
    }

    private void PlaySelectSound()
    {
        if (audioSource != null && selectSound != null)
        {
            audioSource.PlayOneShot(selectSound);
        }
    }
}

