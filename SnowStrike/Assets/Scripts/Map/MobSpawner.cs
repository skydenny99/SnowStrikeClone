using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour {

    public List<GameObject> monsterList = new List<GameObject>();
    public float normalSpawnCycle = 8f;
    public float variation = 3f;
    public float burstSpawnCycle = 1f;
    public int index = 0;

    public bool burstMode = false;
    private List<int> mobQueue = new List<int>();
    private float spawnTimer = 0;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (!burstMode)
        {
            NormalSpawnMob();
        }
        else
        {
            if (burstSpawnCycle < spawnTimer)
            {
                if (mobQueue[index] != null)
                    BurstSpawnMob(mobQueue[index++]);
                else
                    index = 0;

            }
        }
    }

    void NormalSpawnMob()
    {
        if (normalSpawnCycle + Random.Range(-variation, variation) < spawnTimer)
        {
            int i = (int)Mathf.Round(Random.Range(0, 1));
            Instantiate(monsterList[i], transform.position, Quaternion.identity);
            spawnTimer = 0;
        }
    }

    void BurstSpawnMob(int index)
    {
         Instantiate(monsterList[index], transform.position, Quaternion.identity);
         spawnTimer = 0;
    }
}
