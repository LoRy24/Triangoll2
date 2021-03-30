using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MpMinimScript : NetworkBehaviour {

    public GameObject cameraObject;

    void Start() {
        if (!isLocalPlayer) return;
        cameraObject.SetActive(true);
    }
}
