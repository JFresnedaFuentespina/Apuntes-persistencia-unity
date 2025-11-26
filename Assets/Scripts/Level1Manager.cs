using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI playerNameText;
    public Button mainMenuButton;
    public Button level2Button;
    void Start()
    {
        Debug.Log("HOLA");
        String playerName = PlayerPrefs.GetString("PlayerName");
        int playerAge = PlayerPrefs.GetInt("PlayerAge");
        playerNameText.text = playerName + " " + playerAge;

        mainMenuButton.onClick.AddListener(MainMenu);
        level2Button.onClick.AddListener(LoadLevel2);
    }

    public void MainMenu()
    {
        Debug.Log("MAINMENU");
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void LoadLevel2()
    {
        Debug.Log("MAINMENU");
        SceneManager.LoadSceneAsync("Level2");
    }

}
