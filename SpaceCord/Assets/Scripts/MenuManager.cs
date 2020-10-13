using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private Material bgMat;

    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void Quit () {
        Application.Quit();
    }

    void Start () {
        bgMat = GetComponent<MeshRenderer>().material;
    }

    void Update () {
        bgMat.mainTextureOffset += Vector2.one * 0.0003f;
    }
}
