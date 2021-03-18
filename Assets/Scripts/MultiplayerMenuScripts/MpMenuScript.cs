using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.UI;
using TMPro;

public class MpMenuScript : MonoBehaviour {

    public GameObject setupMenu;
    public GameObject multiplayerMenu;
    public MpPlayerSettingsScript settingsScript;

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
}
