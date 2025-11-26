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
    public Button forgetButton;
    public Toggle rememberMeToggle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveButton.onClick.AddListener(Save);
        playButton.onClick.AddListener(LoadLevel1);
        forgetButton.onClick.AddListener(Forget);
        String rememberMe = PlayerPrefs.GetString("RememberMe");
        if (rememberMe == "True")
        {
            nameInput.text = PlayerPrefs.GetString("PlayerName");
            ageInput.text = PlayerPrefs.GetInt("PlayerAge").ToString();
        }
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
        PlayerPrefs.SetInt("PlayerAge", age);
        PlayerPrefs.SetString("RememberMe", rememberMe.ToString());
        PlayerPrefs.Save();
    }

    public void LoadLevel1()
    {
        SceneManager.LoadSceneAsync("Level1");
    }

    public void Forget()
    {
        nameInput.text = "";
        ageInput.text = "";
        PlayerPrefs.DeleteAll();
    }
}
