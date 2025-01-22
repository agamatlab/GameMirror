using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GodBehaviour : MonoBehaviour
{
    // God is responsible for changing scenes
    // Storing PlayerData like moves and GunProperties, cards in a future implementation

    bool FirstPlayerPicking= true;
    bool CardPickingSceneActive = false;
    bool FightSceneActive = false;

    public static GodBehaviour Instance; // Singleton instance
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

    void Start()
    {
        Debug.Log("Start");
        StartCardPicking();
    }

    void StartCardPicking()
    {
        CardPickingSceneActive = true;
        if (FirstPlayerPicking)
        {
            Debug.Log("CardPicking");
            SceneManager.LoadScene(sceneName: "CardPicking");

        }
        else
        {
            Debug.Log("CardPicking");
            SceneManager.LoadScene(sceneName: "CardPicking");
        }

        Debug.Log("Setting Active");
        transform.GetChild(0).gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (CardPickingSceneActive)
        {
            //Debug.Log("CardPickingSceneActive");
        }
    }
}
