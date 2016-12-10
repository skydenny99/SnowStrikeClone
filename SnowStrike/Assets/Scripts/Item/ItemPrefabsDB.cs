using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPrefabsDB : MonoBehaviour {

    public GameObject[] items;

    public GameObject getItem(int id)
    {
        GameObject t = items[id];
        return t;
    }
}
