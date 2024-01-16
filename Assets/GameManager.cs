using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameIsOver;

    public GameObject gameOverUI;

    public SceneFader sceneFader;

    public GameObject completeLevelUI;

    PlayerStats playerStats;

    private void Start()
    {
        gameIsOver = false;
        playerStats = GetComponent<PlayerStats>(); 
    }

    void Update()
    {

        if (gameIsOver)
        {
            return;
        }

        if (playerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        //gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameIsOver = true;
        //completeLevelUI.SetActive(true);
    }
}