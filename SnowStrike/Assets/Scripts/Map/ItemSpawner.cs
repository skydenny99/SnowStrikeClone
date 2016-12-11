using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public ItemManager itemManager;
    public Transform spawnPoint;
    public float respawnTime;

    private float _timer = 0;

	// Use this for initialization
	void Start () {
        _timer = respawnTime;
        if(itemManager == null)
            itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
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

    public void Take()
    {
        _timer = 0;
    }


}
