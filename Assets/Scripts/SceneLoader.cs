using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMap()
    {
        SceneManager.LoadScene("MapScene");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Wyjscie z gry!");
    }
}