using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerSystem : MonoBehaviour {
    
    public int theScore;
    public int hp;
    public bool gameOver;
    SpawnerScript mySpawnerScript;
    public Transform dropshipPrefab;

    private void Start()
    {
        theScore = 0;
        hp = 5;
        gameOver = false;
       
        mySpawnerScript = GameObject.Find("spawner").GetComponent<SpawnerScript>();
    }

    void Update () {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("game1", LoadSceneMode.Single);
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
        if(gameOver)
            GUILayout.Label("Score: " + theScore + "\nGame over. Press 'R' to restart.");
        else
            GUILayout.Label("Score: " + theScore + "\nHP: " + hp);
    }    
}
