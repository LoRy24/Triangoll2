using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using System.Collections.Generic;

public class MpPlayer : NetworkBehaviour {

    [SyncVar]
    public string nickname = "";

    public float speed = 3f;
    public Transform player;

    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10);

    public static GameScript gameManager;

    void Start() {
        player = transform.transform;
        if (isLocalPlayer) {
            nickname = MpSettingsSavingSystem.GetPlayerSettings().playerName;
            gameManager.playersMap.Add(nickname, this);
        }
    }
   
    void HandleMovement() {
        if (!isLocalPlayer) return;
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - player.position.x, mousePosition.y - player.position.y);
        player.transform.up = direction;

        float vertical = Input.GetAxis("Vertical");
        player.position += transform.up * vertical * Time.deltaTime * speed;
    }

    void FixedUpdate() {
        if (isLocalPlayer) {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(Camera.main.transform.position, desiredPosition, smoothSpeed);
            Camera.main.transform.position = smoothPosition;
        }
        HandleMovement();
    }

    public override void OnStopServer() {
        SceneManager.LoadScene(2);
    }
}
