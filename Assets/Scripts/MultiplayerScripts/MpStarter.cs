using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpStarter : MonoBehaviour {

    public enum ConnectType {
        CONNECT, CREATE
    }

    public string nickname, color; // ok
    public ConnectType type;
    public string address = "localhost";
    public int port = 7777;

    void Start() {
        PlayerSettingsData settingsData = MpSettingsSavingSystem.GetPlayerSettings();
        nickname = settingsData.playerName;
        color = MpPlayerSettingsScript.colors[settingsData.triangleColorInteger];
    }
}
