using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuCont : MonoBehaviour
{
    bool Paused = false;
    public Camera MainCam;
    public Camera PauseCam;
    public Toggle pause;

    void Start()
    {
        MainCam.enabled = true;
        PauseCam.enabled = false;
    }

    void Update()
    {

    }

    public void ResumeGaame()
    {
        MainCam.enabled = !MainCam.enabled;
        PauseCam.enabled = !PauseCam.enabled;
        Time.timeScale = 1.0f;
        Paused = false;
        CheckPause();
        pause.isOn = true;
    }

    public void returnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CheckPause()
    {
        if (Paused == true)
        {
            MainCam.enabled = !MainCam.enabled;
            PauseCam.enabled = !PauseCam.enabled;
            Time.timeScale = 1.0f;
            Paused = false;
        }
        else
        {
            MainCam.enabled = !MainCam.enabled;
            PauseCam.enabled = !PauseCam.enabled;
            Time.timeScale = 0.0f;
            Paused = true;
        }
    }
}    
