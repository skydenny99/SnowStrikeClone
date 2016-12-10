using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public GameObject[] items;

    public GameObject getItem(int id)
    {
        return items[id];
    }
    public int getItemCount()
    {
        return items.Length;
    }
}
