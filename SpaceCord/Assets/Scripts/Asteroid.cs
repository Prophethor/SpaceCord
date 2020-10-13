using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public ParticleSystem asteroidDeath;

    private GameManager gm;
    private int hp = 100;

    private void Start () {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update () {
        if ((transform.position - Camera.main.transform.position).magnitude > 100) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("BulletR") || collision.gameObject.layer == LayerMask.NameToLayer("BulletL")) {
            hp -= 50;
            if (hp <= 0) {
                Instantiate(asteroidDeath, transform.position, Quaternion.identity);
                Die();
            }
        }
    }

    public void Die () {
        gm.Score(Random.Range(10, 16));
        Instantiate(asteroidDeath, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
