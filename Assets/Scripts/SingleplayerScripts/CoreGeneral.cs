using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreGeneral : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject diedMenu;
    public GameObject winMenu;

    public StatsManagement stats;

    void Start() {
        float timeSpeed = pauseMenu.activeSelf ? 0f : 1f;
        Time.timeScale = timeSpeed;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) SetPause();
        if (stats.aliveEnemies == 0) {
            winMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void SetPause() {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        float timeSpeed = pauseMenu.activeSelf ? 0f : 1f;
        Time.timeScale = timeSpeed;
    }

    public void RestartLevel() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void GoToMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
