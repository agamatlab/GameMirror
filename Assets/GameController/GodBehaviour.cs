using System.Collections;
using System.Collections.Generic;
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

    private void Update()
    {
        if (CardPickingSceneActive)
        {
            int pickedCard = cardWasPicked();
            if (pickedCard != 0)
            {
                applyCardToPlayer(pickedCard);
                CardPickingSceneActive = false;

                /*For testing purposes only*/
                StartFightingScene();
                /*For testing purposes only*/
            }
        }

        if (FightSceneActive)
        {
            // Check if one of the players dead
        }
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

    void StartFightingScene()
    {
        FightSceneActive = true;
        SceneManager.LoadScene(sceneName: "FightScene");
    }

    int cardWasPicked()
    {
        // Checks if the player has picked a card
        // Returns 0 if no card was picked, 1 if first card, 2 is secon
        if (!transform.GetChild(0).GetChild(0).gameObject.activeSelf)
        {
            return 1;
        }
        else if (!transform.GetChild(0).GetChild(1).gameObject.activeSelf)
        {
            return 2;
        }
        else return 0;
    }

    void applyCardToPlayer(int pickedCard)
    {
        GunProperties cardProperties = transform.GetChild(0).GetChild(pickedCard - 1).GetComponent<CardBehaviour>().GetGunProperties();
        // Apply the picked card to the player
        if (FirstPlayerPicking)
        {
            GunPropertiesP1.addAnother(cardProperties);
        }
        else
        {
            GunPropertiesP2.addAnother(cardProperties);
        }
    }
}
