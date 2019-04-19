using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Enemy : Character
    {
        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            Debug.Log("The enemy just took damage!");
        }

        public override void Die()
        {
            Debug.Log("The character that die was an enemy!");
        }
    }
}

