using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int bricks = 24;
    public float resetDelay = 1f;
    public Text livesText;

    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksReset;
    public GameObject paddleReset;
    public GameObject deathParticles;
    public static GameManager instance = null;

    private GameObject clonePaddle;

    // Start is called before the first frame update
    void Start()
    {
        // Checks if the Game Manger exists
        if (instance = null)
            instance = this;
        // Delete the old one
        else if (instance != this)
            Destroy(gameObject);

    }

    public void Setup()
    {
        clonePaddle = Instantiate(paddleReset, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksReset, transform.position, Quaternion.identity);
    }

    public void checkEndGame()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("Reset", resetDelay);
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Invoke("Reset", resetDelay);
        }
    }

    void resetGame()
    {
        Time.timeScale = 1f;
        // To load scene
        SceneManager.LoadScene("Breakout", LoadSceneMode.Single);
    }

    public void loseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("resetPaddle", resetDelay);
        checkEndGame();
    }

    void resetPaddle()
    {
        clonePaddle = Instantiate(paddleReset, transform.position, Quaternion.identity) as GameObject;
    }

    public void destroyBrick()
    {
        bricks--;
        checkEndGame();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
