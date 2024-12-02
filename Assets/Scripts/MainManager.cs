using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Sprite shipSprite;
    public float highestScore;
    public string highestScoreName;
    public string playerName;

    
    private void Awake()
    {
        LoadHighestScore();
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log(Application.persistentDataPath);

       
    }

    [System.Serializable] class SaveData
    {
        public float highestScore;
        public string highestScoreName;
        
    }

    public void SaveHighestScore()
    {
        SaveData data = new SaveData();
        data.highestScore = highestScore;
        data.highestScoreName = highestScoreName;
        

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highestScore = data.highestScore;
            highestScoreName = data.highestScoreName;
        }
    }
}
