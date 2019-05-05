using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TextRPG
{
    public class UIController : MonoBehaviour
    {
        // Player delegates
        public delegate void OnPlayerUpdateHandler();
        public static OnPlayerUpdateHandler OnPlayerStatChange;
        public static OnPlayerUpdateHandler OnPlayerInventoryChange;
        // Enemy deleages - Pass Enemy as parameter as there are multiple enemy
        // instances in the game
        public delegate void OnEnemyUpdateHandler(Enemy enemy);
        public static OnEnemyUpdateHandler OnEnemyUpdate;

        [SerializeField]
        Text playerStatsText, enemyStatsText, playerInventoryText;
        [SerializeField]
        Player player;
        // Start is called before the first frame update
        void Start()
        {
            // Assign methods to our delegates
            OnPlayerStatChange += UpdatePlayerStats;
            OnPlayerInventoryChange += UpdatePlayerInventory;
            OnEnemyUpdate += UpdateEnemyStats;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateEnemyStats(Enemy enemy)
        {
            if (enemy)
            {
                enemyStatsText.text = string.Format("{0}: {1} Energy, {2} Attack,  {3} Defense",
                    enemy.Description, enemy.Energy, enemy.Attack, enemy.Defense);
            }
            else
            {
                enemyStatsText.text = "";
            }

        }

        public void UpdatePlayerStats()
        {
            playerStatsText.text = string.Format("Player: {0} Energy, {1} Attack,  {2} Defense, {3} Gold ",
                player.Energy, player.Attack, player.Defense, player.Gold);
        }

        public void UpdatePlayerInventory()
        {
            playerInventoryText.text = "Items: ";
            foreach (string item in player.Inventory)
            {
                playerInventoryText.text += item + ", ";
            }
            // Account for gold in chest
            UpdatePlayerStats();
        }
    }
}
