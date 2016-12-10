using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public ItemPrefabsDB itemManager;
    public Transform spawnPoint;
    public float respawnTime;

    private float _timer = 0;

	// Use this for initialization
	void Start () {
        _timer = respawnTime;
        if(itemManager == null)
            itemManager = GameObject.Find("Item Manager").GetComponent<ItemPrefabsDB>();
	}
    
    void SpawnItem()
    {
        GameObject g = itemManager.getItem(Random.Range(0, itemManager.items.Length));
        GameObject child = (GameObject)Instantiate(g, spawnPoint.transform.position, Quaternion.identity);
        child.transform.parent = transform;
    }
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
		if(_timer > respawnTime)
        {
            SpawnItem();
        }
	}

    public void Consume()
    {
        _timer = 0;
    }


}
