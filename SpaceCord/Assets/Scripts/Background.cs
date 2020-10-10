using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public GameObject background;
    public Transform left, right;

    private Material bgMat;

    [HideInInspector]
    public static float camLeft, camRight, camUp, camDown;

    void CalculateCamBorders (float distance) {

        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Mathf.Clamp(Mathf.Abs(distance) / 1.5f, 5, 8),0.01f); 
        //background.transform.localScale = new Vector3(Camera.main.orthographicSize * 4, Camera.main.orthographicSize * 4);

        Vector3 newPos = Vector3.Lerp(Camera.main.transform.position, (left.transform.position + right.transform.position) / 2, 0.007f);
        newPos.z = -10;
        Camera.main.transform.position = newPos;

        camLeft = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.rect.x, 0)).x;
        camRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0f)).x;
        camUp = Camera.main.ScreenToWorldPoint(new Vector3(0f, Camera.main.pixelHeight)).y;
        camDown = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.rect.y, 0)).y;
    }

    void Start()
    {
        bgMat = background.GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        Vector2 dir = left.transform.position - right.transform.position;
        CalculateCamBorders(dir.magnitude);
        bgMat.mainTextureOffset += Vector2.one * 0.00025f;
    }
}
