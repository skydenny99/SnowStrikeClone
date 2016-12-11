using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialWeapon : MonoBehaviour, Weapon {
    private GameObject player_;

    public int level = 1;
    public float damage = 1;
    public float damageInc = 0;
    public float range = 5;
    public float rangeInc = 0;
    public float speed = 1;
    public float speedInc = 0;
    public float caveSpawnRate = 0;
    public float forestSpawnRate = 0;

    public int itemcode = 0;
    public string itemname = "";

    public void Attack()
    {
    }

    public int getItemCode()
    {
        return itemcode;
    }

    public int getLevel()
    {
        return level;
    }

    public string getName()
    {
        return itemname;
    }
    
    public void setLevel(int level)
    {
        this.level = level;
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public float getCaveSpawnRate()
    {
        return caveSpawnRate;
    }

    public float getForestSpawnRate()
    {
        return forestSpawnRate;
    }

    public float getAttackSpeed()
    {
        return speed + (level - 1) * speedInc;
    }
}
