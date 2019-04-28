using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Raccoon : Enemy
    {
        // Start is called before the first frame update
        void Start()
        {
            Energy = 10;
            Attack = 5;
            Defense = 3;
            Gold = 20;
            Inventory.Add("Bandit Mask");
            Description = "A rabid Raccoon with blood pooring out of it's eyes.";
        }
    }
}
