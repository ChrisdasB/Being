using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public static class SaveManager
{
    // Handles saving and loading data in binary

    static string path = Application.persistentDataPath + "/save.data";

    // Check, if we have a savegame, if not, create a blank one
    public static bool CheckForSaveGame()
    {        
        if (!File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);            
            stream.Close();

            return false;
        }
        else
        {
            return true;
        }    
    }

    // Save given data
    public static void SaveData(SaveData newSaveData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);            

        formatter.Serialize(stream, newSaveData);
        stream.Close();
    }

    // Load data
    public static SaveData LoadData()
    {
        if(File.Exists(path)) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData loadedData = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return loadedData;
        }
        else
        {
            Debug.LogError("File not found in " + path);
            return null;
        }
    }

}

