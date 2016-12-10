using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPrefabsDB : MonoBehaviour {

    public Transform[] items;

    public void getItem(int id)
    {
        for(int i = 0; i< items.Length; i++)
        {
            items[i].GetComponent<Item>().
        }
    }
}
