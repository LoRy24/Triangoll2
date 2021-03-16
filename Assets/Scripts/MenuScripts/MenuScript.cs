using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public void GoToMainLevel() {
        SceneManager.LoadScene(1);
    }

    public void CloseGame() {
        Application.Quit();
        Debug.Log("Game Closed!");
    }
}
