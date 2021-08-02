using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObj;
    public float spawnTime = 15f;

    void Start()
    {
        Instantiate(spawnObj, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (spawnTime <= 0f)
        {
            Instantiate(spawnObj, transform.position, Quaternion.identity);
            spawnTime = 15f;
        }
        else spawnTime -= Time.deltaTime;
    }
}
