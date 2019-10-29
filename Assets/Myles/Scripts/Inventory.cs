using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myles
{
    public enum Item
    {
        None,
        Paper,
        Shovel,
        ChestKey,
        Axe,
        Stick,
        GateKey
    }
    public class Inventory 
    {
        public readonly static Inventory main = new Inventory();

        public Dictionary<Item, bool> items = new Dictionary<Item, bool>();
                
        public Item itemBeingUsed = Item.None;

        public bool HasItem(Item item)
        {
            if (!items.ContainsKey(item)) return false;

            return items[item];

        }

        public void Set(Item item, bool shouldHave = true)
        {
            if (items.ContainsKey(item))
            {
                items[item] = shouldHave;
            }
            else
            {
                items.Add(item, shouldHave);
            }
        }

               
        private Inventory()
        {

        }

        
    }
}
