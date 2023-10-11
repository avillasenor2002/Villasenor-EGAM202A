using UnityEngine;
using Cinemachine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Room2 : MonoBehaviour
{
    public int characterCountNeeded = 3;

    public List<Room1> listOfConnectedCharacters;
    
    // Set this in the Unity inspector
    public GameObject Treasure;
    public enum Rarity
    {
        Bronze,
        Silver,
        Gold,
    }
}
