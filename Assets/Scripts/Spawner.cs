using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObj;

    void Start()
    {
        Instantiate(spawnObj, transform.position, Quaternion.identity);
    }
}
