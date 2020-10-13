using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public enum Colors { Red, Blue }

public class EnemySpawner : MonoBehaviour
{
    public Rigidbody2D UFO;
    public Rigidbody2D Asteroid;
    public float minTimeBetweenSpawn = 3, maxTimeBetweenSpawn = 6, asteroidSpeed = 7, UFOSpeed = 8;
    private Transform[] spawnPoints;

    private void Start () {
        spawnPoints = GetComponentsInChildren<Transform>();
        StartCoroutine(SpawnStuff());
    }

    private void Update () {
        if ((transform.position - Camera.main.transform.position).magnitude > 50) Destroy(gameObject);
    }


    IEnumerator SpawnStuff() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn));
            int type = Random.Range(0, 3);
            int index = Random.Range(1, spawnPoints.Length);
            float point1 = Random.Range(-5, 5), point2 = Random.Range(-5, 5);
            if (type == 2) {
                Rigidbody2D asteroid = Instantiate(Asteroid, spawnPoints[index].position, Quaternion.identity);
                asteroid.velocity = (new Vector3(point1, point2) + Camera.main.transform.position - spawnPoints[index].transform.position).normalized * asteroidSpeed;
                asteroid.angularVelocity = 60;
                float size = Random.Range(0.5f, 2);
                asteroid.transform.localScale = new Vector3(size, size);
            } else { 
                Rigidbody2D ufo = Instantiate(UFO, spawnPoints[index].position, Quaternion.identity);
                ufo.velocity = (new Vector3(point1, point2) + Camera.main.transform.position - spawnPoints[index].transform.position).normalized * UFOSpeed;
                ufo.GetComponent<UFO>().color = (Colors) Random.Range(0, 2);
                ufo.angularVelocity = 180;
                float size = Random.Range(1f, 1.5f);
                ufo.transform.localScale = new Vector3(size, size);
            }
        }
    }
}
