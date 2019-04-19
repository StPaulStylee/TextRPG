using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class ItemDatabase : MonoBehaviour
    {
        public static List<string> Items { get; set; } = new List<string>();
        public static ItemDatabase Instance { get;  private set; }

        // Called before any start method is called, which is why we are using it - we 
        // want to ensure our items list is populated before any Players or other characthers
        // are instantiated
        private void Awake()
        {
            // If our Instance is equal to ItemDatabase but it isn't THIS instance, destroy it
            // as we already have one created
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                // Otherwise, set the Instance to this instance as it doesn't matter if we reassign it or 
                // it hasn't yet been created
                Instance = this;
            }

            Items.Add("Emerald Slipper");
            Items.Add("Empty Chalice");
            Items.Add("Bowtie");
        }
    }
}

