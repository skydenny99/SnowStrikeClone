using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour, Item {
    public enum EquipmentType {
        None,
        MeleeWeapon,
        RangedWeapon,
        AerialWeapon
    };

    public EquipmentType equipmentType = EquipmentType.None;
    public int level = 1;
    public float range = 1;
    public float rangeInc = 0;
    public float damage = 1;
    public float damageInc = 0;
    public int itemcode = 0;
    public string itemname = "";

    public Equipment()
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
}
