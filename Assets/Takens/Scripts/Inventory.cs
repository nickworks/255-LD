using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Takens
{

    public enum ItemType { empty, keyOne, keyTwo, tinderBox, hammer, nightStandKey, candleStick, codeBreaker, message}
    

    public class Inventory
    {
        

        private static Inventory _main = new Inventory();
        public static Inventory main
        {
            get
            {
                return _main;
            }
        }


        public Dictionary<ItemType, bool> Items = new Dictionary<ItemType, bool>();
        public ItemType selectedItem = ItemType.empty;

        public bool hasItem(ItemType i)
        {
            if (!Items.ContainsKey(i))
                return false;

            return Items[i];
        }

        public void Set(ItemType i, bool shouldHave = true)
        {
            if (Items.ContainsKey(i))
            {
                Items[i] = shouldHave;
            }
            else
            {
                Items.Add(i, shouldHave);
            }
        }

       // public bool hasFirstKey;
        public bool hasUnlockedDoorOne;
      //  public bool hasSecondKey;
        public bool hasUnlockedDoorTwo;
        public bool hasCompletedLightPuzzle = false;
        public bool hasCompletedCandleStick = false;
        public Dictionary<int, int> code = new Dictionary<int, int>(); 
        public Dictionary<int, int> currentCode = new Dictionary<int, int>();
        public bool completedGame = false;
    }
}
