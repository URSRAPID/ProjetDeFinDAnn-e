
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataScript
{
    public static string file_path() { return Application.dataPath + "/Savedata.mine"; }

    public static SaveData LoadData()
    {
        if (File.Exists(file_path()))
        {
            string loaded_data = File.ReadAllText(file_path());
            SaveData lod = JsonUtility.FromJson<SaveData>(loaded_data);
            return lod;
        }
        else
        {
            return new SaveData();
        }
    }
    public static void Refresh()
    {
        SaveData data = new SaveData();

        string json_data = JsonUtility.ToJson(data);
        File.WriteAllText(file_path(), json_data);
    }
    public static void Save_game()
    {
        SaveData data = LoadData();
        float scoreTemp = GameObject.FindObjectOfType<ScoreController>().GetScoreModel().GetScore().GetValue();
        switch (SceneManager.GetActiveScene().name)
        {
            case "SampleScene":
                if (scoreTemp> data.bestScoreLVL1)
                {
                    data.bestScoreLVL1 = scoreTemp;
                }
                data.accesLVL2 = true;
                break;

            case "Level 2":
                if (scoreTemp > data.bestScoreLVL2)
                {
                    data.bestScoreLVL2 = scoreTemp;
                }
                data.accesLVL3 = true;
                break;
            case "Level 3":
                if (scoreTemp > data.bestScoreLVL3)
                {
                    data.bestScoreLVL3 = scoreTemp;
                }
                break;
        }
        
            

        string json_data = JsonUtility.ToJson(data);
        File.WriteAllText(file_path(), json_data);
    }
}

