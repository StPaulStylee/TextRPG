﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Raccoon : Enemy
    {
        // Start is called before the first frame update
        void Start()
        {
            Energy = 20;
            Attack = 3;
            Defense = 5;
            Gold = 30;
            Inventory.Add("Walrus Tooth");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}