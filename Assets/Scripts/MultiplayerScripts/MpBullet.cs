using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpBullet : MonoBehaviour {
    
    public float speed = 20f;
    public new Rigidbody2D rigidbody;
    public bool isLaunched = false;
    private MpPlayer launcher;

    public void launchBullet(MpPlayer player) {
        launcher = player;
        isLaunched = true;
    }

    void Update() {
        if (!isLaunched) return;
        rigidbody.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        Destroy(gameObject);
        MpPlayer player = hitInfo.GetComponent<MpPlayer>();
        if (player != null) {
            player.takeDamage(15, launcher);
        }
    }
}
