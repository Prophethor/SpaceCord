using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public ParticleSystem explosion;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
