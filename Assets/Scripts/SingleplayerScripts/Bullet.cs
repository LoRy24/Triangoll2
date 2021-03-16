using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;
    public new Rigidbody2D rigidbody;

    void Update() {
        rigidbody.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        Destroy(gameObject);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(50);
        }
    }
}
