using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject itemManager; 

	// Use this for initialization
	void Start () {
        if(itemManager == null)
            itemManager = GameObject.Find("Item Manager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
