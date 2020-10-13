using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterControls : MonoBehaviour
{
    public Transform HPBar;
    public Transform target;
    public Rigidbody2D missile;
    
    public string axisX, axisY, shootButton;
    public float speed = 10f;
    public float missileSpeed = 15;

    private int hp = 100;

    private GameManager gm;
    private Rigidbody2D rb; 

    private float horMov, verMov;
    private Vector2 dir;

    private void Start () {
        gm = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!gm.isOver) {

            dir = target.position - transform.position;

            horMov = Input.GetAxis(axisX);
            verMov = Input.GetAxis(axisY);
            if (horMov > 0 && transform.position.x > Background.camRight) horMov = 0;
            else if (horMov < 0 && transform.position.x < Background.camLeft) horMov = 0;
            if (verMov > 0 && transform.position.y > Background.camUp) verMov = 0;
            else if (verMov < 0 && transform.position.y < Background.camDown) verMov = 0;

            if (Input.GetButtonDown(shootButton)) Shoot(missile);

        }
    }

    private void FixedUpdate () {
        transform.position += new Vector3(horMov, verMov) * 0.5f;
        HPBar.position = transform.position + new Vector3(-HPBar.localScale.x / 2, 1.5f);
        transform.rotation = Quaternion.Euler(0, 0, -Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg);
    }

    private void Shoot(Rigidbody2D missile) {
        Rigidbody2D rb = Instantiate(missile,transform.position,Quaternion.identity);
        rb.rotation = -Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        rb.velocity = dir.normalized*missileSpeed;
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        hp -= 20;
        gm.Score(Random.Range(-7, -4));
        HPBar.GetChild(0).localScale = new Vector3((float) hp / 100 , HPBar.GetChild(0).localScale.y);
        if (hp <= 0) gm.GameOver();
    }
}
