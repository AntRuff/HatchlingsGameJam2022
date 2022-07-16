using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoonSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private float spawnTime = 5f;
    private float curSpawnTime = 0;
    public bool isNight = false;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Transform target;

    // Update is called once per frame
    void Update()
    {
        if (isNight)
        {
            if (curSpawnTime >= spawnTime)
            {
                var goon = Instantiate(prefab);
                goon.GetComponent<EnemyBehavoir>().target = target;
                goon.transform.position = transform.position;
                DayNightManager.Instance.goons.Add(goon);
                curSpawnTime = 0;
            }
            else
            {
                curSpawnTime += Time.deltaTime;
            }
        }
    }
}
