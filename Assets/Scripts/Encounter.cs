﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TextRPG
{
    public class Encounter : MonoBehaviour
    {
        public Enemy Enemy { get; set; }
        [SerializeField]
        private Player player;
        [SerializeField]
        private Button[] dynamicControls;
        
        public void DisableDynamicControls()
        {
            foreach (Button button in dynamicControls)
            {
                button.interactable = false;
            }
        }

        public void EnableCombatButtons()
        {
            this.Enemy = player.Room.Enemy;
            // Enable the attack and flee buttons
            dynamicControls[0].interactable = true;
            dynamicControls[1].interactable = true;
        }

        public void EnableExit()
        {
            dynamicControls[2].interactable = true;
        }

        public void EnableItemChest()
        {
            dynamicControls[3].interactable = true;
        }

        public void Attack()
        {
            int playerDamageAmount = (int)Random.value * (player.Attack - Enemy.Defense);
            int enemyDamageAmount = (int)Random.value * (Enemy.Attack - player.Defense);
            Journal.Instance.Log("<color=#59ffa1>You attacked, dealing <b>" + playerDamageAmount + "</b> damage!</color>");
            Journal.Instance.Log("<color=#59ffa1>You enemy relatiated, dealing<b>" + enemyDamageAmount + "</b> damage!</color>");
            player.TakeDamage(enemyDamageAmount);
            Enemy.TakeDamage(playerDamageAmount);
        }

        public void Flee()
        {
            int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - (player.Defense * 0.5f)));
            player.Room.Enemy = null;
            player.TakeDamage(enemyDamageAmount);
            Journal.Instance.Log("<color=#59ffa1>You fled, but not before taking <b>" + enemyDamageAmount + "</b> damage!</color>");
            player.Investigate();
        }

    }
}