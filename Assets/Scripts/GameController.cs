using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public int bestScore;
    public Text bestScoreText;
    public int life = 3;
    public Text lifeText;
    public GameObject gameOver;
    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CheckLife();
    }
    public void ScoreTextUpdate()
    {
        scoreText.text = score.ToString();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
    }

    public void Load()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
    }

    private void CheckLife()
    {
        if(life < 0)
        {
            ShowGameOver();
        }
    }
     public void LifeTextUpdate()
     {
        switch (life)
        {
            case 3:
                lifeText.text = "";
                break;
            case 2:
                lifeText.text = "X";
                break;
            case 1:
                lifeText.text = "XX";
                break;
            case 0:
                lifeText.text = "XXX";
                break;
            default:
                break;
        }
     }

    private void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
