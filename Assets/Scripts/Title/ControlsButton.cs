using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ControlsButton : MonoBehaviour
{
    private void Start()
    {
        var button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("ControlsScreen");
        });
    }
}