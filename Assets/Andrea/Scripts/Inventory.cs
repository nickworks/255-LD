using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andrea
{
    public enum Item
    {
        None,
        Ticket,
        BusPass,
        Sword,
        Fish,
        Cat,
        Money,
        Battery,
        Key
    }

    public enum AreaAccess
    {
        None,
        Arcade
    }

    public class Inventory
    {
        public readonly static Inventory singleton = new Inventory();

        public Dictionary<Item, bool> items = new Dictionary<Item, bool>();
        public Dictionary<AreaAccess, bool> areas = new Dictionary<AreaAccess, bool>();

        public Item itemSelected = Item.None;

        public Item item1 = Item.Ticket;

        public bool HasItem(Item item)
        {
            if (!items.ContainsKey(item))
            {
                return false;
            }
            return items[item];
        }

        public void Set(Item item, bool beingAdded = true)
        {
            if (items.ContainsKey(item))
            {
                items[item] = beingAdded;
            }
            else
            {
                items.Add(item, beingAdded);
            }
        }

        public bool HasAccess(AreaAccess area)
        {
            if (!areas.ContainsKey(area))
            {
                return false;
            }
            return areas[area];
        }

        public void SetAccess(AreaAccess area, bool beingAdded = true)
        {
            if (areas.ContainsKey(area))
            {
                areas[area] = beingAdded;
            }
            else
            {
                areas.Add(area, beingAdded);
            }
        }

        private Inventory()
        {
            //Set(Item.BusPass);
            SetAccess(AreaAccess.None);
        }
    }

}