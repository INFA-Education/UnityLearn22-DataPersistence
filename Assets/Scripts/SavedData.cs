using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavedData : MonoBehaviour
{
    public static SavedData Instance;
    public string CurrentPlayerName;
    public string BestScorePlayerName;
    public int BestScore = 0;


    public bool CheckBestScore(int score)
    {
        if (score < BestScore) return false;

        BestScorePlayerName = CurrentPlayerName;
        BestScore = score;

        SaveBestScoreData();

        return true;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScoreData();
    }

    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int Score;
    }

    public void SaveBestScoreData()
    {
        SaveData data = new SaveData();
        data.Name = BestScorePlayerName;
        data.Score = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
    public void LoadBestScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        //Debug.Log(path); //если хочется узнать где этот файл находится
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScorePlayerName = data.Name;
            BestScore = data.Score;
        }
        else
        {
            BestScorePlayerName = "";
            BestScore = 0;
        }
    }

}
