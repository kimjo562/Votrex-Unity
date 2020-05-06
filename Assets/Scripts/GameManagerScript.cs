using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public int lives = 3;
    public float resetDelay = 1f;
    public Text livesText;

    public Camera camera;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksReset;
    public GameObject paddleReference;
    private GameObject currentPaddle;
    public GameObject deathParticles;
    public static GameManagerScript instance = null;

    // Start is called before the first frame update
    void Start()
    {
        currentPaddle = Instantiate(paddleReference, transform.position, Quaternion.identity);
        currentPaddle.GetComponent<PaddleBehaviour>().cam = camera;
    }

    public void checkEndGame()
    {
        // Check Lose Condition
        if (lives < 1)
        {
            gameOver.SetActive(true);
            StartCoroutine(RestartGame());
        }
    }

    public void resetGame()
    {
        Time.timeScale = 1f;
        // To load scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loseLife()
    {
        // Lose one life
        lives--;
        livesText.text = "Lives: " + lives;

        // Puts the paddle back after losing one life.
        Instantiate(deathParticles, paddleReference.transform.position, Quaternion.identity);
        Destroy(currentPaddle);
        StartCoroutine(RespawnPaddle());
        // Checks the if player is out of Lives
        checkEndGame();
    }

    void resetPaddle()
    {
        // Respawns the paddle
        currentPaddle = Instantiate(paddleReference, transform.position, Quaternion.identity);
        currentPaddle.GetComponent<PaddleBehaviour>().cam = camera;
    }

    IEnumerator RespawnPaddle()
    {
        yield return new WaitForSeconds(2.0f);
        resetPaddle();
    }

    public IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        resetGame();
    }
}
