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
        String playerName = PlayerPrefs.GetString("PlayerName");
        int playerAge = PlayerPrefs.GetInt("PlayerAge");
        playerNameText.text = playerName + " " + playerAge;

        mainMenuButton.onClick.AddListener(MainMenu);
        level2Button.onClick.AddListener(LoadLevel2);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadSceneAsync("Level2");
    }

}
