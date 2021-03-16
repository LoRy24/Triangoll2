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

    public PlayerSettingsData playerSettingsData;

    public TMP_InputField nameInput;
    public TMP_Dropdown dropdown;
    public GameObject setupMenu;

    void Start() {
        playerSettingsData = MpSettingsSavingSystem.HasSaved() ? MpSettingsSavingSystem
            .GetPlayerSettings() : new PlayerSettingsData("Player", 0);
        nameInput.text = playerSettingsData.playerName;
        dropdown.value = playerSettingsData.triangleColorInteger;
    }

    void Update() {
        playerSettingsData.playerName = nameInput.text;
        playerSettingsData.triangleColorInteger = dropdown.value;
    }

    public void saveAndGotoMultiplayer() {
        MpSettingsSavingSystem.SaveData(playerSettingsData);
        setupMenu.SetActive(false);
        Debug.Log("Data saved!");
    }
}
