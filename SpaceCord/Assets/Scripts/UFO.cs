using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public Sprite[] colorSprites;
    public Colors color;

    private void Start () {
        if (color == Colors.Blue) {
            GetComponent<SpriteRenderer>().sprite = colorSprites[0];
        } else if (color == Colors.Red) {
            GetComponent<SpriteRenderer>().sprite = colorSprites[1];
        }
        else GetComponent<SpriteRenderer>().sprite = colorSprites[2];
    }

    public void Die() {
        Destroy(gameObject);
    }
}
