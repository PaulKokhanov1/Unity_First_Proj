using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int playerHighScore;
    public Text scoreText;
    public Text highScore;
    public GameObject gameOverScreen;
    [SerializeField] public AudioSource flapFX;
    [SerializeField] public AudioSource hitFX;

    public AudioClip Flap;
    public AudioClip HitWall;

    private void Start()
    {
        
        flapFX.clip = Flap;
        hitFX.clip = HitWall;
        highScore.text = "High Score: " + playerHighScore.ToString();
    }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("highScore")){
            playerHighScore = PlayerPrefs.GetInt("highScore");
        }
    }


    [ContextMenu("Increase Score")]
    public void addScore(int scoreToADD)
    {
        playerScore = playerScore + scoreToADD;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        savePrefs();

    }

    private void OnDestroy()
    {
        savePrefs();
    }

    //for highscore data saving
    void savePrefs()
    {
        if (!PlayerPrefs.HasKey("highScore") )
        {
            PlayerPrefs.SetInt("highScore", playerScore);
            
        } else if (PlayerPrefs.GetInt("highScore") < playerScore)
        {
            PlayerPrefs.SetInt("highScore", playerScore);
        }
        PlayerPrefs.Save();

    }

}
