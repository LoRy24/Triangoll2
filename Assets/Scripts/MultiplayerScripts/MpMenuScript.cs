using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
