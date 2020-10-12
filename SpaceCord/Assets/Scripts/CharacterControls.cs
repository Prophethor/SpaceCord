using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterControls : MonoBehaviour
{
    public GameObject target;
    public Rigidbody2D missile;
    
    public string axisX, axisY, shootButton;
    public float speed = 10f;
    public float missileSpeed = 15;

    private GameManager gm;

    private float horMov, verMov;
    private Vector2 dir;

    private void Start () {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        dir = target.transform.position - transform.position;

        horMov = Input.GetAxis(axisX);
        verMov = Input.GetAxis(axisY);
        if (horMov > 0 && transform.position.x > Background.camRight) horMov = 0;
        else if (horMov < 0 && transform.position.x < Background.camLeft) horMov = 0;
        if (verMov > 0 && transform.position.y > Background.camUp) verMov = 0;
        else if (verMov < 0 && transform.position.y < Background.camDown) verMov = 0;

        transform.position += new Vector3(horMov, verMov) * 1/speed;
        transform.rotation = Quaternion.Euler(0, 0, -Mathf.Atan2(dir.x,dir.y) * Mathf.Rad2Deg);

        if (Input.GetButtonDown(shootButton)) Shoot(missile);
    }

    private void Shoot(Rigidbody2D missile) {
        Rigidbody2D rb = Instantiate(missile,transform.position+transform.up*0.5f,Quaternion.identity);
        rb.rotation = -Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        rb.velocity = dir.normalized*missileSpeed;
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            gm.Score(-5);
        else if (collision.gameObject.layer == LayerMask.NameToLayer("BulletL") ||
                 collision.gameObject.layer == LayerMask.NameToLayer("BulletR")) gm.GameOver();
    }
}
