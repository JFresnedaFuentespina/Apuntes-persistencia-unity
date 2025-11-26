using System;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField ageInput;

    public Button saveButton;
    public Button playButton;
    public Button forgetButton;
    public Toggle rememberMeToggle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveButton.onClick.AddListener(Save);
        playButton.onClick.AddListener(LoadLevel1);
        forgetButton.onClick.AddListener(Forget);
        //! START CON PLAYERPREFFS
        // String rememberMe = PlayerPrefs.GetString("RememberMe");
        // if (rememberMe == "True")
        // {
        //     nameInput.text = PlayerPrefs.GetString("PlayerName");
        //     ageInput.text = PlayerPrefs.GetInt("PlayerAge").ToString();
        // }
        //! START CON JSON
        string jsonPath = Application.persistentDataPath + "/player.json";
        if (File.Exists(jsonPath))
        {
            try
            {
                string json = File.ReadAllText(jsonPath);
                PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(json);
                rememberMeToggle.isOn = playerData.rememberMe;
                if (playerData.rememberMe)
                {
                    nameInput.text = playerData.name;
                    ageInput.text = playerData.age.ToString();
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning("Error al cargar el JSON " + e.Message);
            }
        }
    }

    public void Save()
    {
        //! SAVE CON PLAYERPREFS
        // string name = nameInput.text;
        // if (!int.TryParse(ageInput.text, out int age))
        // {
        //     Debug.LogWarning("Invalid age input! Please enter a number.");
        //     return;
        // }
        // bool rememberMe = rememberMeToggle.isOn;

        // PlayerPrefs.SetString("PlayerName", name);
        // PlayerPrefs.SetInt("PlayerAge", age);
        // PlayerPrefs.SetString("RememberMe", rememberMe.ToString());
        // PlayerPrefs.Save();
        //! SAVE CON JSON
        PlayerData player = new PlayerData();
        player.name = nameInput.text;

        if (!int.TryParse(ageInput.text, out int age))
        {
            Debug.LogWarning("La edad no es un número válido");
            return;
        }
        player.age = age;
        player.rememberMe = rememberMeToggle.isOn;
        string json = JsonConvert.SerializeObject(player);
        string path = Application.persistentDataPath + "/player.json";
        File.WriteAllText(path, json);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadSceneAsync("Level1");
    }

    public void Forget()
    {
        nameInput.text = "";
        ageInput.text = "";
        //! FORGET CON PLAYERPREFS
        // PlayerPrefs.DeleteAll();
        //! FORGET CON JSON
        string path = Application.persistentDataPath + "/player.json";
        if (File.Exists(path))
        {
            File.Delete(path);

        }
    }
}
