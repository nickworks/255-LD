using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Andrea
{
    public class Task
    {
        public List<Goal> Goals { get; set; } = new List<Goal>();
        public Item ItemReward { get; set; }
        public bool Completed { get; set; }

        public void CheckGoals()
        {
            Completed = Goals.All(g => g.Completed);
            if (Completed)
            {
                GiveReward();
            }
        }

        void GiveReward()
        {
            if (ItemReward != Item.None)
            {
                Inventory.singleton.Set(ItemReward);
            }
        }

    }
}