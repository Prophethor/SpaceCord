using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static int points;

    private void Start () {
        points = 0;
    }

    public void Score(int p) {
        points += p;
        Debug.Log(points);
    }

    public void GameOver() {
        Time.timeScale = 0;
    }
}
