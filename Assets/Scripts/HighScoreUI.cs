using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoresText;

    void Start()
    {
        scoresText.text = "";

        int position = 1;

        foreach (ScoreEntry score in DataManager.Instance.scores)
        {
            scoresText.text +=
                position +
                " - " +
                score.playerName +
                " : " +
                score.score +
                "\n";

            position++;
        }
    }
}