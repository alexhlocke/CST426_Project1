using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("References")]
    public GameObject pauseMenu;
    public GameObject mainUI;

    private bool isPaused = false;

    
    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            pause();
        }
    }

    public void pause() {
        isPaused = !isPaused;

        if (isPaused) {
            pauseMenu.SetActive(true);
            mainUI.SetActive(false);
            Time.timeScale = 0;
        } else {
            pauseMenu.SetActive(false);
            mainUI.SetActive(true);
            Time.timeScale = 1;
        }        
    }
}
