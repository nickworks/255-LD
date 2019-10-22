using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Petzak
{
    public enum Item
    {
        None,
        Shirt,
        Pants,
        Gloves
    }

    public class Inventory
    {
        public static readonly Inventory main = new Inventory();

        public Dictionary<Item, bool> items = new Dictionary<Item, bool>();

        public Item selectedItem = Item.Shirt;

        public bool HasItem(Item item)
        {
            if (items.ContainsKey(item))
                return items[item];
            return false;
        }

        public void Set(Item item, bool shouldHave = true)
        {
            if (items.ContainsKey(item))
                items[item] = shouldHave;
            else
                items.Add(item, shouldHave);
        }

        private Inventory()
        {
            //items.Add(Item.Shirt, true);
            //items.Add(Item.Pants, false);
            //items.Add(Item.Gloves, false);
        }
    }
}