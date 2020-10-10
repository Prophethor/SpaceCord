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

    private float horMov, verMov;
    private Vector2 dir;

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
}
