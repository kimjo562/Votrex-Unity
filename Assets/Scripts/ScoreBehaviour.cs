using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour
{
    [SerializeField]
    GameManagerScript gameManager;

    public float brickCount = 24.0f;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = "Bricks: " + brickCount.ToString();
        checkEndGame();
    }

    public void checkEndGame()
    {
        // Check Win Condition
        if (brickCount < 1)
        {
            gameManager.youWon.SetActive(true);
            Time.timeScale = 0.5f;
            StartCoroutine(gameManager.RestartGame());
        }
    }
}

