using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : MonoBehaviour, Ownable {
    public enum EquipmentType {
        None,
        MeleeWeapon,
        RangedWeapon,
        AerialWeapon
    };

    public Equipment()
    {
    }

    public abstract float getRange();

    public abstract float getDamage();

    public abstract bool isExplosive();

    public abstract string getName();
    
    public abstract EquipmentType getType();

    public abstract int getLevel();
    public abstract void setLevel(int level);
    /*
    public virtual bool attack(int attackType)
    {
        return false;
    }*/
}
