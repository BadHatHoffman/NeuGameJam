using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObj;
    public float spawnTime = 15f;
    public int limit = 5;

    void Start()
    {
        Instantiate(spawnObj, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (spawnTime <= 0f)
        {
            if(limit > 0)
            {
                Instantiate(spawnObj, transform.position, Quaternion.identity);
                limit--;
            }
            spawnTime = 15f;
        }
        else spawnTime -= Time.deltaTime;
    }
}
