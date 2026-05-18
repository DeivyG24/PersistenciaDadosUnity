using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;

    public GameObject GameOverText;

    public TextMeshProUGUI PlayerNameText;
    public TextMeshProUGUI BestScoreText;

    private bool m_Started = false;
    private int m_Points;
    private bool m_GameOver = false;

    void Start()
    {
        // PLAYER NAME
        if (GameManager.Instance != null)
        {
            PlayerNameText.text =
                "Player: " +
                GameManager.Instance.playerName;
        }

        // BEST SCORE
        UpdateBestScoreText();

        const float step = 0.6f;

        int perLine =
            Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray =
            new[] { 1, 1, 2, 2, 5, 5 };

        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position =
                    new Vector3(
                        -1.5f + step * x,
                        2.5f + i * 0.3f,
                        0
                    );

                var brick =
                    Instantiate(
                        BrickPrefab,
                        position,
                        Quaternion.identity
                    );

                brick.PointValue =
                    pointCountArray[i];

                brick.onDestroyed
                    .AddListener(AddPoint);
            }
        }
    }

    void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;

                float randomDirection =
                    Random.Range(-1.0f, 1.0f);

                Vector3 forceDir =
                    new Vector3(
                        randomDirection,
                        1,
                        0
                    );

                forceDir.Normalize();

                Ball.transform.SetParent(null);

                Ball.AddForce(
                    forceDir * 2.0f,
                    ForceMode.VelocityChange
                );
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;

        ScoreText.text =
            "Score : " + m_Points;
    }

    public void GameOver()
    {
        if (m_GameOver)
        {
            return;
        }

        m_GameOver = true;

        GameOverText.SetActive(true);

        if (DataManager.Instance != null)
        {
            DataManager.Instance.AddScore(
                GameManager.Instance.playerName,
                m_Points
            );

            UpdateBestScoreText();
        }
    }

    void UpdateBestScoreText()
    {
        if (
            DataManager.Instance != null &&
            DataManager.Instance.scores.Count > 0
        )
        {
            ScoreEntry bestScore =
                DataManager.Instance.scores[0];

            BestScoreText.text =
                "Best: " +
                bestScore.playerName +
                " : " +
                bestScore.score;
        }
    }
}