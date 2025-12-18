using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string gameScene;

    public string optionsScene;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(gameScene); // replace with your scene name
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void ShowOptions()
    {
        SceneManager.LoadScene(optionsScene);
    }
}
