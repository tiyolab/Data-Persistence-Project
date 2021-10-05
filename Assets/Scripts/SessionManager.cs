using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public static SessionManager Instance;
    public string playerName;
    public string playerBestScoreName;
    public int playerBestScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
        LoadPlayerInfo();
    }

    [System.Serializable]
    class BestScore
    {
        public string name;
        public int score;
    }

    [System.Serializable]
    class PlayerInfo
    {
        public string name;
    }

    public void SaveBestScore()
    {
        BestScore saveData = new BestScore();
        saveData.name = playerBestScoreName;
        saveData.score = playerBestScore;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScore saveData = JsonUtility.FromJson<BestScore>(json);

            playerBestScoreName = saveData.name;
            playerBestScore = saveData.score;
        }
    }

    public void SavePlayerInfo()
    {
        PlayerInfo saveData = new PlayerInfo();
        saveData.name = playerName;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/playerinfo.json", json);
    }

    public void LoadPlayerInfo()
    {
        string path = Application.persistentDataPath + "/playerinfo.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerInfo saveData = JsonUtility.FromJson<PlayerInfo>(json);

            playerName = saveData.name;
        }
    }

}
