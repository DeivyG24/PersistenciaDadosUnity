using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputName;

    public void StartGame()
    {
        GameManager.Instance.playerName =
            inputName.text;

        SceneManager.LoadScene("Main");
    }

    public void OpenHighScore()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}