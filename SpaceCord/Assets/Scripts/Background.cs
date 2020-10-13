using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform blue, red;

    private GameManager gm;
    private Material bgMat;
    private Vector2 dir;

    [HideInInspector]
    public static float camLeft, camRight, camUp, camDown;

    void CalculateCamBorders () {
        camLeft = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.rect.x, 0)).x;
        camRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0f)).x;
        camUp = Camera.main.ScreenToWorldPoint(new Vector3(0f, Camera.main.pixelHeight)).y;
        camDown = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.rect.y, 0)).y;
    }

    void Start()
    {
        bgMat = GetComponent<MeshRenderer>().material;
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        dir = blue.transform.position - red.transform.position;
        CalculateCamBorders();
        bgMat.mainTextureOffset += Vector2.one * 0.0003f;
    }

    private void FixedUpdate () {
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Mathf.Clamp(Mathf.Abs(dir.magnitude) / 2f, 7, 10), 0.05f);

        Vector3 newPos = Vector3.Lerp(Camera.main.transform.position, (blue.transform.position + red.transform.position) / 2, 0.05f);
        newPos.z = -10;
        Camera.main.transform.position = newPos;
    }
}
