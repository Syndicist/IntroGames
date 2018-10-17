using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private string[] scenePaths;
    public Button game1Button;
    public Button game2Button;
    public Button game3Button;
    public bool sceneUnloaded;

    void Awake()
    {
        //Make this script persistent(Not destroy when loading a new level)
        //DontDestroyOnLoad(this);

        Time.timeScale = 1.0f; //In case some game does not UN-pause..'
        sceneUnloaded = false;
        scenePaths = new string[3]{"game1", "game2", "game3"};
    }
    
    public void LoadScene(int level)
    {
        SceneManager.UnloadSceneAsync("menu");
        SceneManager.LoadScene(scenePaths[level], LoadSceneMode.Single);
    }
}
