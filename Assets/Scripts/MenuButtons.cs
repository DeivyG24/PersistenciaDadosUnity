using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void OpenHighScore()
    {
        SceneManager.LoadScene("HighScore");
    }
}