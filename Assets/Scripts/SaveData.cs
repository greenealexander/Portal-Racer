using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveData
{

    public static void Save(string level, float score)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/" + level + ".score");
        bf.Serialize(file, score);
        file.Close();
    }

    public static float Load(string level)
    {
        if (File.Exists(Application.dataPath + "/" + level + ".score"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/" + level + ".score", FileMode.Open);
            float score = (float)bf.Deserialize(file);
            file.Close();
            return score;
        }
        return 1000f;
    }

    public static void saveClearedLevels()
    {
		BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/cleared.levels");
        bf.Serialize(file, GameController.ClearedLevels);
        file.Close();
    }

    public static void loadClearedLevels()
    {
		if (File.Exists(Application.dataPath + "/cleared.levels"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/cleared.levels", FileMode.Open);
            bool[] clearedLevels = (bool[])bf.Deserialize(file);
            file.Close();
            GameController.ClearedLevels = clearedLevels;
        }
		else GameController.ClearedLevels = new bool[] { false, false, false, false, false };
    }
}
