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

    [SyncVar(hook = nameof(updateKillsValue))]
    public int kills;

    public float speed = 3f;
    private Transform player;

    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10);

    public static GameScript gameManager;
    public static NetworkManager networkManager;

    public TMPro.TMP_Text nicknameText;
    public TMPro.TMP_Text hpText;
    public GameObject textsContainer;

    public GameObject minimapPrefab;
    private GameObject newMinimapObj;

    public Transform bulletSpawn;
    public GameObject mpBulletPrefab;

    public GameObject playerPrefab;

    void Start() {
        player = transform.transform;
        nickname = MpSettingsSavingSystem.GetPlayerSettings().playerName;
        healt = 150;
        newMinimapObj = Instantiate(minimapPrefab);
        newMinimapObj.transform.position = player.position;
        if (isLocalPlayer) teleportToRandomSpawnPoint();
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
        nicknameText.text = nickname;
        hpText.text = healt + "HP";
    }

    private void Update() {
        if (!isLocalPlayer) return;
        if (Input.GetButtonDown("Fire1")) fireBullet();
    }

    public void teleportToRandomSpawnPoint() {
        System.Random random = new System.Random();
        transform.position = gameManager.spawnPoints[random.Next(0, 5)].transform.position;
    }

    void updateNicknameText(string oldVal, string newVal) {
        nicknameText.text = newVal;
        nickname = newVal;
    }

    void updateHealtValue(int oldVal, int newVal) {
        hpText.text = newVal + "HP";
        healt = newVal;
    }

    void updateKillsValue(int oldVal, int newVal) { kills = newVal; }

    public override void OnStopClient() {
        if (!isLocalPlayer) return;
        SceneManager.LoadScene(2);
    }

    public void takeDamage(int damage, MpPlayer damager) {
        if (healt - damage <= 0) die(damager);
        healt -= damage;
    }

    public void die(MpPlayer killer) {
        teleportToRandomSpawnPoint();
        healt = 150;
        killer.kills++;
    }

    public void fireBullet() {
        if (isClientOnly) {
            fireOnServer();
            return;
        }
        fireOnClients();
    }

    public void fire() {
        MpBullet bullet = Instantiate(mpBulletPrefab, bulletSpawn.position,
            bulletSpawn.transform.rotation).GetComponent<MpBullet>();
        bullet.launchBullet(this);
    }

    [Command]
    public void fireOnServer() { 
        fireOnClients();
    }

    [ClientRpc]
    public void fireOnClients() {
        fire();
    }
}
