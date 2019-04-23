using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class World : MonoBehaviour
    {
        // The [,] creates a 2D array
        public Room[,] Dungeon { get; set; }
        public Vector2 DungeonGrid;

        private void Awake()
        {
            // This defines the size of our 2D array of rooms
            Dungeon = new Room[(int)DungeonGrid.x, (int)DungeonGrid.y];
            StartCoroutine(GenerateFloor());
        }

        public IEnumerator GenerateFloor()
        {
            Debug.Log("Generating Floor.");
            for (int x = 0; x < DungeonGrid.x; x++)
            {
                for (int y = 0; y < DungeonGrid.y; y++)
                {
                    // This is just a fancy way of initializing an object and assigning propery values
                    Dungeon[x, y] = new Room
                    {
                        RoomIndex = new Vector2(x, y)
                    };
                }
            }

            // This will execute everything above this yield statement then once it get's here,
            // it will wait for 5 seconds before it resumes - maintaining all of the state from before
            // but in a completely different frame (non-blocking)
            Debug.Log("Finding Exit Location...");
            yield return new WaitForSeconds(5);

            // Assign one of our rooms to be an exitLocation for the Dungeon, remember that we set DungeonGrid 
            // values from the inspector
            Vector2 exitLocation = new Vector2((int)Random.Range(0, DungeonGrid.x), (int)Random.Range(0, DungeonGrid.y));
            // Then set the room to be an exit and ensure that if it was empty that is no longer empty
            Dungeon[(int)exitLocation.x, (int)exitLocation.y].IsExit = true;
            Dungeon[(int)exitLocation.x, (int)exitLocation.y].IsEmpty = false;
            Debug.Log("Exit is at: " + exitLocation);
        }
    }
}