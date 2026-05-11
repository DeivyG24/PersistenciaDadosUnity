using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputName;

    public void StartGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.playerName = inputName.text;
        }

        SceneManager.LoadScene("Main");
    }
}