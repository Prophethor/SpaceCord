using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public enum Colors { Red, Blue, None }

public class EnemySpawner : MonoBehaviour
{
    public Rigidbody2D UFO;

    private Transform[] spawnPoints;

    private void Start () {
        spawnPoints = GetComponentsInChildren<Transform>();
        StartCoroutine(SpawnAsteroids());
    }

    private void Update () {
        if ((transform.position - Camera.main.transform.position).magnitude > 50) Destroy(gameObject);
    }


    IEnumerator SpawnAsteroids() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(4f,7f));
            int index = Random.Range(1, spawnPoints.Length);
            float point1 = Random.Range(-5, 5), point2 = Random.Range(-5, 5);
            Rigidbody2D ufo = Instantiate(UFO,spawnPoints[index].position,Quaternion.identity);
            ufo.velocity = (new Vector3(point1,point2) + Camera.main.transform.position - spawnPoints[index].transform.position).normalized * 5;
            ufo.GetComponent<UFO>().color = (Colors) Random.Range(0, 3);
        }
    }
}
