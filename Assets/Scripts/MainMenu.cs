using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject audio;
    private FlatAudioManager audioManager;

    void Awake() {
        audio = GameObject.Find("Audio");
        audioManager = audio.GetComponent<FlatAudioManager>();
    }

    void Start() {
        audioManager.playFlatSound("Jazz");
    }

//audioManager.playFlatSound("Select");

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SandBoxGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
