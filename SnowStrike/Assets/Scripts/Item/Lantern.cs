using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : Equipment {

    public int level = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override float getRange()
    {
        return 1.0f * (level / 2);
    }

    public override float getDamage()
    {
        return 5.0f * level;
    }

    public override bool isExplosive()
    {
        return level > 5;
    }

    public override string getName()
    {
        return "item";
    }

    public override EquipmentType getType()
    {
        return EquipmentType.MeleeWeapon;
    }

    public override int getLevel()
    {
        return level;
    }

    public override void setLevel(int level)
    {
        this.level = level;
    }
}
