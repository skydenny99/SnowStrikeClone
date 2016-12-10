using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour, Weapon {
    private GameObject player_;

    public GameObject bullet;
    public int level = 1;
    public float damage = 1;
    public float damageInc = 0;
    public float speed = 1;
    public float speedInc = 0;
    public float range = 1;
    public float rangeInc = 0;
    public float caveSpawnRate = 0;
    public float forestSpawnRate = 0;

    public int itemcode = 0;
    public string itemname = "";

    public void Attack()
    {
        if (player_ == null)
            player_ = GameObject.FindGameObjectWithTag("Player");

        Ray2D ray = new Ray2D(player_.transform.position, player_.transform.localScale.x > 0 ? Vector2.left : Vector2.right);
        
        Debug.DrawRay(ray.origin, ray.direction * range, Color.red, 1f);
        RaycastHit2D[] hitList = Physics2D.RaycastAll(ray.origin, ray.direction, range + (rangeInc * (level-1)));
        foreach( RaycastHit2D hit in hitList)
        {
            if (hit.collider != null && hit.collider.CompareTag("Monster"))
            {
                hit.collider.GetComponent<Monster>().Damaged((int)damage);
            }
        }
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
		//player_ = GameObject.FindGameObjectWithTag("Player");
       // Debug.Log(player_);
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
}
