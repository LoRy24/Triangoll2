using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using System.Collections.Generic;

public class MpPlayer : NetworkBehaviour {

    [SyncVar(hook=nameof(updateNicknameText))]
    public string nickname;

    public float speed = 3f;
    public Transform player;

    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10);

    public static GameScript gameManager;
    public static NetworkManager networkManager;
    public TMPro.TMP_Text nicknameText;

    public GameObject minimapPrefab;
    private GameObject newMinimapObj;

    void Start() {
        player = transform.transform;
        nickname = MpSettingsSavingSystem.GetPlayerSettings().playerName;
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
        nicknameText.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void updateNicknameText(string oldVal, string newVal) {
        nicknameText.text = newVal;
        nickname = newVal;
    }

    public override void OnStopClient() {
        if (!isLocalPlayer) return;
        SceneManager.LoadScene(2);
    }
}
