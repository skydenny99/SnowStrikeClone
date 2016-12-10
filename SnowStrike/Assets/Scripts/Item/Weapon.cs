using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Weapon : Item {
    void Attack();
    /*
    public int level = 1;
    public float range = 1;
    public float rangeInc = 0;
    public float damage = 1;
    public float damageInc = 0;
    public int itemcode = 0;
    public string itemname = "";
    protected GameObject player_;

    private void Start()
    {
        player_ = GameObject.FindGameObjectWithTag("Player");
    }

    public Weapon()
    {
    }

    public string getName()
    {
        return itemname;
    }

    public int getItemCode()
    {
        return itemcode;
    }

    public void Attack()
    {
        
    }*/
}
