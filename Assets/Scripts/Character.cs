using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
