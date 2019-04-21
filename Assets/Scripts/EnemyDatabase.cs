using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class EnemyDatabase : MonoBehaviour
    {
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        public static EnemyDatabase Instance { get; set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            // This is the same as doing a foreach loop over a specified collection
            // One disadvantage of doing this is you can't really log details during development
            Enemies.AddRange(GetComponents<Enemy>());
            // For Dev only
            foreach(Enemy enemy in GetComponents<Enemy>())
            {
                Debug.Log("Found enemy of type " + enemy.GetType());
            }
        }

        public Enemy GetRandomEnemy()
        {
            return Enemies[Random.Range(0, Enemies.Count)];
        }
    }
}

