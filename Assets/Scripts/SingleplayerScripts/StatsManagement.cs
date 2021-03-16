using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsManagement : MonoBehaviour {
    
    public float aliveEnemies = 0f;
    public float kills = 0f;
    public Player player;

    public TextMeshProUGUI aliveEnemiesText;
    public TextMeshProUGUI killsText;
    public Slider slider;
    public TextMeshProUGUI hpText;

    void Update() {
        aliveEnemiesText.text = "Alive Enemies: " + aliveEnemies;
        killsText.text = "Kills: " + kills;
        slider.value = player.healt /  100;
        hpText.text = "HP: " + player.healt + "+";
    }
}
