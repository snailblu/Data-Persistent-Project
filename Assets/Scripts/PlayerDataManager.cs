using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int highScore;
}

public class PlayerDataManager : MonoBehaviour
{

    public static PlayerDataManager Instance;

    public PlayerData playerData = new PlayerData();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadPlayerData();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerName(string name)
    {
        playerData.playerName = name;
    }

    public void SetHighScore(int score)
    {
        if (score > playerData.highScore)
        {
            playerData.highScore = score;
        }
    }

    public void SavePlayerData()
    {
        string dataAsJson = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("PlayerData", dataAsJson);
        PlayerPrefs.Save();
    }
    public void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            string dataAsJson = PlayerPrefs.GetString("PlayerData");
            playerData = JsonUtility.FromJson<PlayerData>(dataAsJson);
        }
    }
}
