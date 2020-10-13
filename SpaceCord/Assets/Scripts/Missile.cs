using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public LayerMask ignore;
    public ParticleSystem ps;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        ParticleSystem _ps = Instantiate(ps, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
