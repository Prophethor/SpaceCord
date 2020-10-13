using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public Sprite[] colorSprites;
    public ParticleSystem UFODeath;
    public Colors color;

    private GameManager gm;

    private void Start () {

        gm = FindObjectOfType<GameManager>();
        if (color == Colors.Blue) {
            GetComponent<SpriteRenderer>().sprite = colorSprites[0];
        } else if (color == Colors.Red) {
            GetComponent<SpriteRenderer>().sprite = colorSprites[1];
        }
    }

    public void Die() {
        gm.Score(Random.Range(10, 16));
        Instantiate(UFODeath, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("BulletR") && color == Colors.Blue) {
                Die();
        } else if (collision.gameObject.layer == LayerMask.NameToLayer("BulletL") && color == Colors.Red) {
                Die();
        }
    }
}
