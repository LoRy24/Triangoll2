using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using System.Collections.Generic;

public class MpPlayer : NetworkBehaviour {

    // Shared data
    [SyncVar(hook = nameof(updateNicknameText))]
    public string nickname;

    [SyncVar(hook = nameof(updateHealtValue))]
    public int healt;

    public float speed = 3f;
    public Transform player;

    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10);

    public static GameScript gameManager;
    public static NetworkManager networkManager;

    public TMPro.TMP_Text nicknameText;
    public TMPro.TMP_Text hpText;
    public GameObject textsContainer;

    public GameObject minimapPrefab;
    private GameObject newMinimapObj;

    void Start() {
        player = transform.transform;
        nickname = MpSettingsSavingSystem.GetPlayerSettings().playerName;
        healt = 150;
        newMinimapObj = Instantiate(minimapPrefab);
        newMinimapObj.transform.position = player.position;
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
        newMinimapObj.transform.position = player.position;
        textsContainer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void teleportToRandomSpawnPoint() {
        System.Random random = new System.Random();
        transform.position = gameManager.spawnPoints[random.Next(0, 5)].transform.position;
    }

    public override void OnStartClient() {
        if (gameManager.playersArray.Contains(nickname)) SceneManager.LoadScene(0);
        if (isLocalPlayer) teleportToRandomSpawnPoint();
        gameManager.playersArray += nickname + "~";
    }

    void updateNicknameText(string oldVal, string newVal) {
        nicknameText.text = newVal;
        nickname = newVal;
    }

    void updateHealtValue(int oldVal, int newVal) {
        hpText.text = newVal + "HP";
        healt = newVal;
    }

    public override void OnStopClient() {
        if (!isLocalPlayer) return;
        SceneManager.LoadScene(2);
    }
}
