using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public GunProperties GunPropertiesP1; // Value to transfer between scenes
    public GunProperties GunPropertiesP2; // Value to transfer between scenes

    void Awake()
    {
        if (Instance == null)
        {
            GunPropertiesP1.setDefault(); // Set default values for player 1
            GunPropertiesP2.setDefault(); // Set default values for player 2

            Instance = this; // Set the singleton instance
            DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate GameManager objects
        }
    }
}
