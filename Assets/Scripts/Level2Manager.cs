using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level2Manager : MonoBehaviour
{
    public Button gameOverButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverButton.onClick.AddListener(LoadGameOver);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadSceneAsync("GameOver");
    }
}
