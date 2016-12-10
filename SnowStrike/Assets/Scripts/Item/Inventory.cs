using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
    public Inventory()
    {
        
    }
    private class ItemData
    {
        public ItemData(GameObject item)
        {
            this.item = item;
        }
        public GameObject item { get; set; }
        public int count { get; set; }
    }
    private List<ItemData> items = new List<ItemData>();
    
    public void AddItem(GameObject item)
    {
        if(item.GetComponent<Ownable>() != null)
        {
            foreach(ItemData it in items)
            {
                if(it.Equals(item))
                {
                    it.count++;
                    return;
                }
            }
            items.Add(new ItemData(item));
        }
    }
}
