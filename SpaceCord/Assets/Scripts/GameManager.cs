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
    public static int points;
    public bool isOver = false;
    public Text pointsText;
    public CanvasGroup GameOverScreen;

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

    public void Retry() {
        SceneManager.LoadScene(1);
    }
    
    public void Continue() {
        SceneManager.LoadScene(0);
    }

    public void GameOver() {
        Time.timeScale = 0;
        GameOverScreen.interactable = true;
        GameOverScreen.blocksRaycasts = true;
        GameOverScreen.alpha = 1;
        isOver = true;
    }
}
