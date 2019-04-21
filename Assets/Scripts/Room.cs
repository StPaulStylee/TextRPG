using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Room : MonoBehaviour
    {
        public ItemChest ItemChest { get; set; }
        public Enemy Enemy { get; set; }
        public bool IsExit { get; set; }
        public bool IsEmpty { get; set; }
        public Vector2 RoomIndex { get; set; }

        public Room(ItemChest chest,Enemy enemy, bool empty, bool exit)
        {
            this.ItemChest = chest;
            this.Enemy = enemy;
            this.IsEmpty = empty;
            this.IsExit = exit;
        }
        public Room()
        {
            int roll = Random.Range(0, 30);
            if (roll > 0 && roll < 6)
            {
                Enemy = EnemyDatabase.Instance.GetRandomEnemy();
                Enemy.RoomIndex = RoomIndex;
            }
            else if (roll > 15 && roll < 20)
            {
                ItemChest = new ItemChest();
            }
            else
            {
                IsEmpty = true;
            }
        }
    }
}

