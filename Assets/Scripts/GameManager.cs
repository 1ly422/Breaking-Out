using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int currentLevel = 1;
    public int score;
    public int lives = 3;

    private void Awake()
    {
        //When you load scene in Unity, it unload previous scenes
        // and destroy all gameObjects, this function make sure to
        // not delete the gameObject this script is attached to.
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        this.score = 0;
        this.lives = 3;

        LoadLevel(1);
    }

    void LoadLevel(int level)
    {
        this.currentLevel = level;

        SceneManager.LoadScene("Level " + level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
