using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        Debug.Log("Boom");
    }
}
