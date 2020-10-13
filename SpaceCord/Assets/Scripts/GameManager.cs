using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Net.Http.Headers;

public class GameManager : MonoBehaviour
{
    
    public Text pointsText;
    public Text pointsTextGO, highscoreTextGO;
    public CanvasGroup GameOverScreen;

    private int highscore;
    private int points;
    private bool isOver = false;

    private void Awake () {
        highscore = PlayerPrefs.GetInt("highscore");
    }

    private void Start () {
        points = 0;
        Time.timeScale = 1;
        isOver = false;
    }

    private void Update () {
        pointsText.text = points.ToString();
    }

    public void Score(int p) {
        points += p;
        Debug.Log(points);
    }

    public bool IsOver () {
        return isOver;
    }

    public void GameOver () {

        if (points > highscore) {
            highscore = points;
            PlayerPrefs.SetInt("highscore", highscore);
            PlayerPrefs.Save();
        }

        Time.timeScale = 0;
        pointsTextGO.text = points.ToString();
        highscoreTextGO.text = highscore.ToString();
        GameOverScreen.interactable = true;
        GameOverScreen.blocksRaycasts = true;
        GameOverScreen.alpha = 1;
        isOver = true;
    }

    public void Retry() {
        SceneManager.LoadScene(1);
    }
    
    public void Continue() {
        SceneManager.LoadScene(0);
    }
}
