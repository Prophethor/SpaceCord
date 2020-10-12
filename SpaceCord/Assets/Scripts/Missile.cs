using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public LayerMask ignore;
    public ParticleSystem ps;

    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D (Collision2D collision) {

        if(gameObject.layer == LayerMask.NameToLayer("BulletL")) {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
                if (collision.gameObject.GetComponent<UFO>().color == Colors.Red) {
                    gm.Score(15);
                    collision.gameObject.GetComponent<UFO>().Die();
                }
                else {
                    gm.Score(-5);
                }
            }
        } else if (gameObject.layer == LayerMask.NameToLayer("BulletR")) {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
                if (collision.gameObject.GetComponent<UFO>().color == Colors.Blue) {
                    gm.Score(15);
                    collision.gameObject.GetComponent<UFO>().Die();
                }
                else {
                    gm.Score(-5);
                }
            }
        }

        ParticleSystem _ps = Instantiate(ps, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
