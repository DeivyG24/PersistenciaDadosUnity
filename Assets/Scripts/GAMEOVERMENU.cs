using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}