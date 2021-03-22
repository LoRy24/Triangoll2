using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MpMenuScript : MonoBehaviour {

    public GameObject setupMenu;
    public GameObject multiplayerMenu;
    public MpPlayerSettingsScript settingsScript;
    public TMP_InputField serverAddress;
    public TMP_InputField serverPort;
    public GameObject errorMenu;

    void Start() {
        if (!MpSettingsSavingSystem.HasSaved()) {
            setupMenu.SetActive(true);
            return;
        }
        multiplayerMenu.SetActive(true);
    }

    public void GotoMenu() {
        SceneManager.LoadScene(0);
    }

    public void StartMultiplayer(bool localHosted) {
        if (!localHosted) {
            if (serverAddress.text.Replace(" ", "") != "" && serverPort.text.Replace(" ", "") != "null") {
                MpLoadingValues.ConnectionType = 0;
                MpLoadingValues.Address = serverAddress.text;
                MpLoadingValues.Port = Int16.Parse(serverPort.text);
                SceneManager.LoadScene(3);
                return;
            }
            errorMenu.SetActive(true);
            return;
        }
        MpLoadingValues.ConnectionType = 1;
        SceneManager.LoadScene(3);
    }
}
