using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Player : Character
    {
        public int Floor { get; set; }
        public Room Room { get; set; }
        [SerializeField]
        private World world;
        // Start is called before the first frame update
        void Start()
        {
            Floor = 0;
            Energy = 30;
            Attack = 10;
            Defense = 5;
            Gold = 0;
            // I don't think this is necessary as we initialize an empty list on Character
            Inventory = new List<string>();
            RoomIndex = new Vector2(2, 2);
            Room = world.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y];
            // Ensure our starting room is empty - Don't love this, starting room should 
            // probably be created in World and then assigned to the player
            Room.IsEmpty = true;
        }

        public void AddItem(string item)
        {
            Journal.Instance.Log("You received  an item: " + item);
            Inventory.Add(item);
        }

        public override void TakeDamage(int amount)
        {
            Debug.Log("Player TakeDamage.");
            base.TakeDamage(amount);
        }

        public override void Die()
        {
            Debug.Log("Player died. Game over!");
            base.Die();
        }

        public void Investigate()
        {
            this.Room = world.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y];
            if (this.Room.IsEmpty)
            {
                Journal.Instance.Log("You find yourself in an empty room.");
            }
            else if (this.Room.ItemChest != null)
            {
                Journal.Instance.Log("You've found an item chest. Open it?");
            }
            else if (this.Room.Enemy != null)
            {
                Journal.Instance.Log("You've encounterd an " + Room.Enemy.Description + ". Fight or flight?");
            }
            else if (this.Room.IsExit)
            {
                Journal.Instance.Log("You've found the exit to the next floor. Go to it?");
            }
        }

        public void Move(int direction)
        {
            //if (this.Room.Enemy)
            //{
            //    return;
            //}
            // Move north if you're not against the northern wall
            // North and West are different as they will always be checking on Zero
            // East and south are more dynamic because we can change the size of the dungeon
            // in the inspector
            if (direction == 0 && RoomIndex.y > 0)
            {
                Journal.Instance.Log("You venture North...");
                RoomIndex -= Vector2.up;
            }
            //East
            // Here, we check the length (-1) of the Dungeon grids first index (x)
            if (direction == 1 && RoomIndex.x < world.Dungeon.GetLength(0) - 1)
            {
                Journal.Instance.Log("You head East...");
                RoomIndex += Vector2.right;
            }
            // South
            if (direction == 2 &&  RoomIndex.y < world.Dungeon.GetLength(1) - 1)
            {
                Journal.Instance.Log("You swing South...");
                RoomIndex -= Vector2.down;
            }
            // West
            if (direction == 3 && RoomIndex.x > 0)
            {
                Journal.Instance.Log("You wander West...");
                RoomIndex += Vector2.left;
            }
            if (this.Room.RoomIndex != RoomIndex)
            {
                Investigate();
            }
        }
    }
}
