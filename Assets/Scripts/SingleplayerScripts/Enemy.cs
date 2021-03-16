using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float healt = 100f;
    public StatsManagement statsManagement;

    void Start() {
        statsManagement.aliveEnemies++;
    }

    void Update() {
        if (healt > 0) return;
        Die();
    }

    public void TakeDamage(float damage) {
        healt -= damage;
    }

    public void Die() {
        Destroy(gameObject);
        statsManagement.aliveEnemies--;
        statsManagement.kills++;
    }
}
