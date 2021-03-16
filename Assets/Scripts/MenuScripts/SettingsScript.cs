using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour {

    public Toggle toggle;

    void Start() {
        Screen.fullScreen = !Screen.fullScreen;
        toggle.isOn = Screen.fullScreen;
        if (!Screen.fullScreen) Screen.SetResolution(1280, 800, FullScreenMode.Windowed, 72);
        else Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow, 72);
        Debug.Log("Fullscreen changed! " + Screen.width + "x" +  Screen.height);
    }

    public void ChangeScreenMode() {
        Screen.fullScreen = toggle.isOn;
        if (!toggle.isOn) Screen.SetResolution(1280, 800, FullScreenMode.Windowed, 72);
        else Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow, 72);
        Debug.Log("Fullscreen changed! " + Screen.width + "x" +  Screen.height);
    }
}
