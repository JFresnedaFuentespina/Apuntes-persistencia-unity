using System;
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
    public Toggle rememberMeToggle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveButton.onClick.AddListener(Save);
        playButton.onClick.AddListener(LoadLevel1);
    }

    public void Save()
    {
        string name = nameInput.text;
        if (!int.TryParse(ageInput.text, out int age))
        {
            Debug.LogWarning("Invalid age input! Please enter a number.");
            return;
        }
        bool rememberMe = rememberMeToggle.isOn;

        PlayerPrefs.SetString("PlayerName", name);
        PlayerPrefs.SetInt("PlayerAge", age); // you can store as int directly
        PlayerPrefs.SetString("RememberMe", rememberMe.ToString());
        PlayerPrefs.Save();
    }

    public void LoadLevel1()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
}
