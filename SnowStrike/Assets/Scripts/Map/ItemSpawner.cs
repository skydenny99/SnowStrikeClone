using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public ItemManager itemManager;
    public Vector3 spawnPoint;
    public float respawnTime;
    public float randomRange;
    public bool isSpawned = false;

    private float _timer = 0;

	// Use this for initialization
	void Start () {
        _timer = respawnTime;
        spawnPoint = transform.position;
        if(itemManager == null)
            itemManager = GameObject.FindGameObjectWithTag("ItemManager").GetComponent<ItemManager>();
	}
    
    void SpawnItem()
    {
        GameObject g = itemManager.getItem(Random.Range(0, itemManager.items.Length));
        GameObject child = (GameObject)Instantiate(g, spawnPoint, Quaternion.identity);
        child.transform.parent = transform;
        isSpawned = true;
    }
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
		if(!isSpawned&&_timer > respawnTime + Random.Range(-randomRange, randomRange))
        {
            SpawnItem();
        }
	}

    public void Take()
    {
        _timer = 0;
    }


}
