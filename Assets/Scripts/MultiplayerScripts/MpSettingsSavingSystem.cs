using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class MpSettingsSavingSystem : MonoBehaviour {

    private static string namePath = Application.persistentDataPath 
        + "/multiplayerpname.triangollopt";
    private static string colorPath = Application.persistentDataPath + "/multiplayerpcolor.triangollopt";

    public static void SaveData(PlayerSettingsData data) {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream nameStream = new FileStream(namePath, FileMode.Create);
        FileStream colorStream = new FileStream(colorPath, FileMode.Create);
        formatter.Serialize(nameStream, data.playerName);
        formatter.Serialize(colorStream, data.triangleColorInteger);
        nameStream.Close(); colorStream.Close();
    }

    public static PlayerSettingsData GetPlayerSettings() {
        if (HasSaved()) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream nameStream = new FileStream(namePath, FileMode.Open);
            FileStream colorStream = new FileStream(colorPath, FileMode.Open);
            PlayerSettingsData data = new PlayerSettingsData((string) formatter.Deserialize(nameStream), 
                (int) formatter.Deserialize(colorStream));
            nameStream.Close(); colorStream.Close();
            return data;
        }
        Debug.LogError("DataFile not found!");
        return null;
    }

    public static bool HasSaved() {
        return File.Exists(namePath) && File.Exists(colorPath);
    }
}
