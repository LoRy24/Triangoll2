using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float healt = 100f;
    public CoreGeneral core;

    void Update() {
        if (healt > 0) return;
        Die();
    }

    public void takeDamage(float damage) {
        float desiredHealt = (healt - damage) < 0f ? 0f : healt - damage;
        healt = desiredHealt;
    }

    public void Die() {
        gameObject.SetActive(false);
        core.diedMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) {
            takeDamage(40);
        }
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Enemy>() != null) {
            takeDamage(40);
        }
    }
}
