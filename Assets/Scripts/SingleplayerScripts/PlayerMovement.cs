using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 3f;
    public Transform player;

    void FixedUpdate() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - player.position.x, mousePosition.y - player.position.y);
        player.transform.up = direction;

        float vertical = Input.GetAxis("Vertical");
        player.position += transform.up * vertical * Time.deltaTime * speed;
    }
}
