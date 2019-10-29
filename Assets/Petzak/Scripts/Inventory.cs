using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Petzak
{
    public enum Item
    {
        None,
        Rock1,
        Rock2,
        Rock3,
        Lasso,
        Slingshot,
        Sword,
        Torch,
        RedKey,
        BlueKey,
        PurpleKey
    }

    public class Inventory
    {
        public static readonly Inventory main = new Inventory();

        public Dictionary<Item, bool> items = new Dictionary<Item, bool>();

        public Item selectedItem = Item.None;

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

        }
    }
}