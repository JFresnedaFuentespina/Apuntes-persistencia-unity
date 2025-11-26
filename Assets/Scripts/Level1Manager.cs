using System;
using System.IO;
using Newtonsoft.Json;
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
        mainMenuButton.onClick.AddListener(MainMenu);
        level2Button.onClick.AddListener(LoadLevel2);
        //! START CON PLAYERPREFS
        // String playerName = PlayerPrefs.GetString("PlayerName");
        // int playerAge = PlayerPrefs.GetInt("PlayerAge");
        // playerNameText.text = playerName + " " + playerAge;
        //! START CON JSON
        string jsonPath = Application.persistentDataPath + "/player.json";
        if (File.Exists(jsonPath))
        {
            try
            {
                string json = File.ReadAllText(jsonPath);
                PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(json);
                playerNameText.text = playerData.name + " " + playerData.age;
            }
            catch (Exception e)
            {
                Debug.LogWarning("Error al cargar el JSON " + e.Message);
            }
        }
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
