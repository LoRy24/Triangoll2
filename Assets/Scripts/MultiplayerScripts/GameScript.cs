using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

    public IDictionary<string, MpPlayer> playersMap = new Dictionary<string, MpPlayer>();
    public IDictionary<MpPlayer, string> playersRegisteredNicksMap = new Dictionary<MpPlayer, string>();
    public GameScript gameScript;

    void Start() {
        MpPlayer.gameManager = gameScript;
    }
}
