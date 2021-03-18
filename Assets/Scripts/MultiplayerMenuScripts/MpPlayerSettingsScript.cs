using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MpPlayerSettingsScript : MonoBehaviour {

    // 0: Blue
    // 1: Red
    // 2: Yellow
    // 3: Green
    // 4: Purple
    // 5: Aqua

    public static string[] colors = {"Blue", "Red", "Yellow", "Green", "Purple", "Aqua"};

    public PlayerSettingsData playerSettingsData;

    public TMP_InputField nameInput;
    public TMP_Dropdown dropdown;
    public GameObject setupMenu;
    public TMP_Text nicknameInfo;
    public TMP_Text colorInfo;

    void Start() {
        playerSettingsData = MpSettingsSavingSystem.HasSaved() ? MpSettingsSavingSystem
            .GetPlayerSettings() : new PlayerSettingsData("Player", 0);
        nameInput.text = playerSettingsData.playerName;
        dropdown.value = playerSettingsData.triangleColorInteger;
        Debug.Log("Loaded!");
        nicknameInfo.text = "Nickname: " + playerSettingsData.playerName;
        colorInfo.text = "Color: " + MpPlayerSettingsScript.colors[playerSettingsData
            .triangleColorInteger];
    }

    void Update() {
        playerSettingsData.playerName = nameInput.text;
        playerSettingsData.triangleColorInteger = dropdown.value;
        nicknameInfo.text = "Nickname: " + playerSettingsData.playerName;
        colorInfo.text = "Color: " + MpPlayerSettingsScript.colors[playerSettingsData
            .triangleColorInteger];
    }

    public void saveAndGotoMultiplayer() {
        MpSettingsSavingSystem.SaveData(playerSettingsData);
        setupMenu.SetActive(false);
        Debug.Log("Data saved!");
    }
}
