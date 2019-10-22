using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jennings { 

    public enum Item {
        None,
        RedKey,
        BlueKey,
        GreenKey,
        OrangeKey
    }

public class Inventory {

        /// <summary>
        /// Our inventory singleton (accessible via Inventory.main)
        /// </summary>
        public static readonly Inventory main = new Inventory();

        public Dictionary<Item, bool> items = new Dictionary<Item, bool>();

        public Item itemBeingUsed = Item.None;

        public bool HasItem(Item item)
        {

            if(!items.ContainsKey(item)) return false;

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

        private Inventory() {

            /*
            items.Add(Item.BlueKey, true); // <- we have armor
            items.Add(Item.RedKey, false); // <- we DON'T have pants
            */

        }
    }
}
