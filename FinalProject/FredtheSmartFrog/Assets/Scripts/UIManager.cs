using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject OptionsPanel;
    public Toggle fScreenToggle;

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
    }

    public void PlayGame()
    {
        //SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("PauseFunction");
    }

    public void Options()
    {
        MainPanel.SetActive(false);
        OptionsPanel.SetActive(true);
        // Slider and Toggle Events
    }

    public void QuitGame()
    {
        // Prompt for exiting game
        // Exiting the Game
        Application.Quit();
    }
}
