using i5.Toolkit.Core.Spawners;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] Spawner spawner;

    [SerializeField] TMP_Text labelText;
    [SerializeField] GameObject playButton;

    float remainingTime;
    int targetCount = 10;
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) return;

        remainingTime -= Time.deltaTime;
        if(remainingTime <= 0)
        {
            remainingTime = spawnInterval;
            if(targetCount <= 0)
            {
                EndGame();
            } else
            {
                SpawnTarget();
            }
        }
    }

    void SpawnTarget()
    {
        if (spawner.Spawn())
        {
            GameObject target = spawner.MostRecentlySpawnedObject();
            target.transform.position = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), 2);
            targetCount--;
            labelText.text = targetCount + " targets remaining...";
        }
    }

    public void StartGame()
    {
        hasStarted = true;
        labelText.text = "Get ready!";
        playButton.SetActive(false);
    }

    public void EndGame()
    {
        playButton.SetActive(true);
        targetCount = 10;
        labelText.text = "Press play!";
        Destroy(spawner.MostRecentlySpawnedObject);
        hasStarted = false;
    }
}
