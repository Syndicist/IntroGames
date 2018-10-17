using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class PlayerSystem : MonoBehaviour {
    
    public int theScore;
    public int highScore;
    public int hp;
    public bool gameOver;
    SpawnerScript mySpawnerScript;
    public Transform dropshipPrefab;

    private void Start()
    {
        theScore = 0;
        highScore = 0;
        hp = 5;
        gameOver = false;

        mySpawnerScript = GameObject.Find("spawner").GetComponent<SpawnerScript>();

        highScore = PlayerPrefs.GetInt("highScore", highScore);
    }

    void Update () {
        if (gameOver)
        {
            if (theScore > highScore)
            {
                highScore = theScore;
                PlayerPrefs.SetInt("highScore", highScore);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SceneManager.UnloadSceneAsync("game1");
                Resources.UnloadUnusedAssets();
                SceneManager.LoadScene("game1", LoadSceneMode.Single);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //SceneManager.UnloadSceneAsync("game1");
                //Resources.UnloadUnusedAssets();
                SceneManager.LoadScene("menu", LoadSceneMode.Single);
            }
        }
        else
        {
            //End the game if out of hp
            if (hp <= 0 && !gameOver)
            {
                Object[] allObjects = FindObjectsOfType(typeof(GameObject));
                foreach (GameObject obj in allObjects)
                {
                    if (obj.transform.name == "EelDog(Clone)")
                    {
                        Destroy(obj);
                    }
                }
                mySpawnerScript.spawning = false;
                gameOver = true;
            }
        }
	}

    //OnGUI is called multiple times per frame. Use this for GUI stuff only!
    void OnGUI()
    {
        //We display the game GUI from the playerscript
        //It would be nicer to have a seperate script dedicated to the GUI though...
        if (gameOver)
        {
            GUILayout.Label("HighScore: " + highScore + "\nScore: " + theScore + "\nGame over. Press 'R' to restart." + "\nPress 'ESC' to return to menu.");
        }
        else
            GUILayout.Label("HighScore: " + highScore + "\nScore: " + theScore + "\nHP: " + hp);
    }    
}
