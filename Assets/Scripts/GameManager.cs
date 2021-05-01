using i5.Toolkit.Core.Spawners;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] Spawner spawner;
    float remainingTime;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if(remainingTime <= 0)
        {
            remainingTime = spawnInterval;
            SpawnTarget();
        }
    }

    void SpawnTarget()
    {
        if (spawner.Spawn())
        {
            GameObject target = spawner.SpawnedInstances[0];
            target.transform.position = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), 2);
        }
    }
}
