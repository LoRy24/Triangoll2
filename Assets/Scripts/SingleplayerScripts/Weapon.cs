using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource audioSource;

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shot();
        }
    }

    public void Shot() {
        if (Time.timeScale != 0f) {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            audioSource.Play(0);
        }
    }
}
