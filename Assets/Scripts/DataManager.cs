using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;

    public List<ScoreEntry> scores =
        new List<ScoreEntry>();

    string savePath;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        savePath =
            Application.persistentDataPath +
            "/savefile.json";

        LoadData();
    }

    public void AddScore(
        string playerName,
        int score
    )
    {
        ScoreEntry newScore =
            new ScoreEntry();

        newScore.playerName =
            playerName;

        newScore.score =
            score;

        scores.Add(newScore);

        scores = scores
            .OrderByDescending(s => s.score)
            .Take(5)
            .ToList();

        SaveData();
    }

    public void SaveData()
    {
        SaveData data =
            new SaveData();

        data.scores = scores;

        string json =
            JsonUtility.ToJson(data, true);

        File.WriteAllText(
            savePath,
            json
        );
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            string json =
                File.ReadAllText(savePath);

            SaveData data =
                JsonUtility.FromJson<SaveData>(json);

            scores = data.scores;
        }
    }
}