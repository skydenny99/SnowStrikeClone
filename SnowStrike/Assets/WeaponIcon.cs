using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour {

    public Sprite basic;
    public Weapon wp;

    void Start()
    {
        GameObject g = GameObject.Find("Item Manager");
       // basic = g.GetComponent<ItemManager>().get
    }

    private bool isSelected = false;
    void Deselected()
    {
        isSelected = false;
        transform.FindChild("Image").GetComponent<Image>().sprite = basic;
    }

    void Selected()
    {
        isSelected = true;
    }
}
