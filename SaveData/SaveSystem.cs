using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    string savePath => Application.persistentDataPath + "/saves/";
    

    public void Save(SaveData saveData)
    {
        string saveFilePath = savePath + "HighScore" + ".json";

        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }

        string saveJson = JsonUtility.ToJson(saveData);

        File.WriteAllText(saveFilePath, saveJson);
        Debug.Log("Save Success: " + saveFilePath);
    }
    public SaveData Load()
    {
        string saveFilePath = savePath + "HighScore" + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.Log("No such saveFile exists");
            return null;
        }

        string saveFile = File.ReadAllText(saveFilePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(saveFile);
        return saveData;
    }
    public void SaveScore()
    {
        string saveFilePath = savePath + "HighScore" + ".json";

        SaveData highscore = new SaveData(GameManager.Instance.score);

        if (!File.Exists(saveFilePath))
        {
            Save(highscore);
        }
        else
        {
            if (Load().highscore <= GameManager.Instance.score)
            {
                Save(highscore);
            }
            else if (Load().highscore > GameManager.Instance.score)
            {
                return;
            }
        }
    }
}
