using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Ball ball;
    private Paddle paddle;
    private Brick[] bricks;

    public int currentLevel = 1;
    public int score;
    public int lives = 3;

    private void Awake()
    {
        //When you load scene in Unity, it unload previous scenes
        // and destroy all gameObjects, this function make sure to
        // not delete the gameObject this script is attached to.
        DontDestroyOnLoad(this.gameObject);


        //we do this to allow OnLevelLoaded to be called everytime a scene is loaded
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
        this.bricks = FindObjectsOfType<Brick>();
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

    private void ResetLevel()
    {
        this.ball.Reset();
        this.paddle.Reset();
    }

    private void GameOver()
    {
        //Load a Game Over scene
        //SceneManager.LoadScene("GameOver");
    }

    public void Hit(Brick brick)
    {
        this.score += brick.points;

        if (Cleared())
        {
            LoadLevel(this.currentLevel + 1);
        }
    }
    public void Fail()
    {
        Console.WriteLine("Fails called");
        if (--this.lives <= 0)
        {
            GameOver();
        }
        else
        {
            ResetLevel();
        }
    }

    private bool Cleared()
    {
        foreach (var b in this.bricks)
        {
            if (b.gameObject.activeInHierarchy && !b.unbreakable)
            {
                return false;
            }
        }
        return true;
    }
}
