using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettingsData {

    public string playerName;
    public int triangleColorInteger;
    
    public PlayerSettingsData(string name, int color) {
        this.playerName = name;
        this.triangleColorInteger = color;
    }
}
