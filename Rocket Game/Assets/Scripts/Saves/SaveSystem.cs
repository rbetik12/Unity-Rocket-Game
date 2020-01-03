using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem {

    private static string path = Application.persistentDataPath + "/player.kek";
    private static BinaryFormatter formatter = new BinaryFormatter();

    public static void SaveData(PlayerData playerData) {
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerData LoadData() {
        if (File.Exists(path)) {
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("File doesn't exist in " + path);
            return null;
        }
    }

}