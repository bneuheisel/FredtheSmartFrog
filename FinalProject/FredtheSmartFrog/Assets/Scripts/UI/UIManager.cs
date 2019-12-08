using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject OptionsPanel;
    public GameObject DifficultyPanel;


    private void Start()
    {
        MainMenu();
    }

    private void Update()
    {
        //IOS Touch Input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
        }
    }

    public void MainMenu()
    {
        MainPanel.SetActive(true);
        OptionsPanel.SetActive(false);
        DifficultyPanel.SetActive(false);
    }

    public void Options()
    {
        MainPanel.SetActive(false);
        OptionsPanel.SetActive(true);
        DifficultyPanel.SetActive(false);
        // Slider and Toggle Events
    }

    public void Difficulty()
    {
        MainPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        DifficultyPanel.SetActive(true);
    }

    public void Easy()
    {
        SceneManager.LoadScene("Easy");
    }

    public void Medium()
    {
        SceneManager.LoadScene("Medium");
    }

    public void Hard()
    {
        SceneManager.LoadScene("Hard");
    }

    public void QuitGame()
    {
        // Prompt for exiting game
        // Exiting the Game
        Application.Quit();
    }
}
