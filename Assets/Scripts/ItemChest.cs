using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class ItemChest : MonoBehaviour
    {
        public string Item { get; set; }
        public int Gold { get; set; }
        public bool IsTrap { get; set; }
        public bool IsHeal { get; set; }
        public Enemy Enemy { get; set; }

        public ItemChest()
        {
            // A number between 0 and 6
            if (Random.Range(0, 7) == 2)
            {
                IsTrap = true;
            }
            else if (Random.Range(0, 5) == 2)
            {
                IsHeal = true;
            }
            else if (Random.Range(0, 5) == 2)
            {
                Enemy = EnemyDatabase.Instance.GetRandomEnemy();
            }
            else
            {
                Item = ItemDatabase.Instance.GetRandomItem();
                Gold = Random.Range(20, 201);
            }
        }
    }
}
