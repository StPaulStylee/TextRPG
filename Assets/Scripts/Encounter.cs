using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TextRPG
{
    public class Encounter : MonoBehaviour
    {
        public Enemy Enemy { get; set; }
        // Event System
        public delegate void OnEnemyDieHandler();
        public static OnEnemyDieHandler OnEnemyDie;

        [SerializeField]
        private Player player;
        [SerializeField]
        private Button[] dynamicControls;

        private void Start()
        {
            OnEnemyDie += Loot;
        }
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
            int playerDamageAmount = Mathf.CeilToInt(Random.value * (player.Attack - Enemy.Defense));
            int enemyDamageAmount = Mathf.CeilToInt(Random.value * (Enemy.Attack - player.Defense));
            Journal.Instance.Log("<color=#59ffa1>You attacked, dealing <b>" + playerDamageAmount + "</b> damage!</color>");
            Journal.Instance.Log("<color=#59ffa1>You enemy relatiated, dealing <b>" + enemyDamageAmount + "</b> damage!</color>");
            player.TakeDamage(enemyDamageAmount);
            Enemy.TakeDamage(playerDamageAmount);
        }

        public void Flee()
        {
            int enemyDamageAmount = Enemy.Attack - player.Defense > 0 ? (int)((Enemy.Attack - player.Defense) * 0.5f) : 1;
            //player.Room.Enemy = null;
            player.TakeDamage(enemyDamageAmount);
            Journal.Instance.Log("<color=#59ffa1>You fled, but not before taking <b>" + enemyDamageAmount + "</b> damage!</color>");
            //player.Investigate();
        }

        public void ExitFloor()
        {
            // Create a new floor == exit current floor
            StartCoroutine(player.world.GenerateFloor());
            player.Floor += 1;
            Journal.Instance.Log("You've found an exit to another floor. You are now on Floor: " + player.Floor);
        }

        public void Loot()
        {
            player.AddItem(this.Enemy.Inventory[0]);
            player.Gold += this.Enemy.Gold;
            Journal.Instance.Log(string.Format("<color=#56ffc7>You've slaing {0}. Searching the body, you find a {1} and {2} gold.</color>",
                this.Enemy.Description, this.Enemy.Inventory[0], this.Enemy.Gold));
            player.Room.Enemy = null;
            player.Room.IsEmpty = true;
            player.Investigate();
        }

        public void OpenChest()
        {
            ItemChest chest = player.Room.ItemChest;
            if (chest.IsTrap)
            {
                player.TakeDamage(2);
                Journal.Instance.Log("It's a trap and you're dealt 2 damage!");
            }
            else if (chest.IsHeal)
            {
                player.TakeDamage(-2);
                Journal.Instance.Log("This is a healing chest and you've restored 2 HP.");
            }
            else if (chest.Enemy)
            {
                player.Room.Enemy = chest.Enemy;
                // Must null the chest here cause we run investigate again
                player.Room.ItemChest = null;
                player.Investigate();
            }
            else
            {
                player.Gold += chest.Gold;
                player.AddItem(chest.Item);
                Journal.Instance.Log("You found: " + chest.Item + " and <color=#ffe556>" + chest.Gold + " gold.</color>");
            }
            // Null the chest here cause we're done with it.
            player.Room.ItemChest = null;
            dynamicControls[3].interactable = false;
            player.Investigate();
        }
    }
}