using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameScript : NetworkBehaviour {

    //public SyncList<string> playersMap = new SyncList<string>();
    
    public GameScript gameScript;
    public NetworkManager networkManager;

    void Start() {
        MpPlayer.gameManager = gameScript;
        MpPlayer.networkManager = networkManager;
    }
}
