﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Character : MonoBehaviour
    {
        public int Energy { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Gold { get; set; }
        // Used to define where our character is in the dungeon
        // Ex: (4, 7)
        public Vector2 RoomIndex { get; set; }
        public List<string> Inventory { get; set; }

        // virtual allows and inherited class to override this method
        public virtual  void TakeDamage(int amount)
        {
            Energy -= amount;
            if (Energy <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            Debug.Log("The Character is Dead!")
        }
    }
}

