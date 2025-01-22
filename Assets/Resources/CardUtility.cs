using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class CardUtility
{
    private static List<CardConfig> cards;

    // Ensure cards are loaded before accessing them
    private static void LoadCardsFromJSON()
    {
        // If already loaded, do nothing
        if (cards != null)
        {
            Debug.Log("Cards already loaded.");
            return;
        }

        string path = "Assets/Resources/Cards.json";

        // Check if the file exists
        if (File.Exists(path))
        {
            // Read the JSON from the file
            string json = File.ReadAllText(path);
            Debug.Log("JSON loaded: " + json);

            // Parse the JSON string into a List of CardConfig
            try
            {
                var cardCollectionWrapper = JsonUtility.FromJson<CardCollectionWrapper>(json);
                cards = cardCollectionWrapper.cards;
                Debug.Log($"Loaded {cards.Count} cards.");
            }
            catch
            {
                Debug.LogError("Failed to parse JSON into card list.");
                cards = new List<CardConfig>();
            }
        }
        else
        {
            Debug.LogError("JSON file not found at path: " + path);
            cards = new List<CardConfig>(); // Initialize an empty list if file doesn't exist
        }
    }

    // Save the cards to JSON
    private static void SaveCardsToJSON()
    {
        string path = "Assets/Resources/Cards.json";
        var cardCollectionWrapper = new CardCollectionWrapper { cards = cards };

        string updatedJson = JsonUtility.ToJson(cardCollectionWrapper, true);

        File.WriteAllText(path, updatedJson);
        Debug.Log("Cards saved to JSON.");
    }

    // Static method to get a card by its index (order)
    public static CardConfig GetCardByIndex(int index)
    {
        LoadCardsFromJSON(); // Ensure cards are loaded before accessing

        if (cards != null && index >= 0 && index < cards.Count)
        {
            return cards[index];
        }

        Debug.LogError("Card index out of range or no cards loaded.");
        return null;
    }

    // Static method to get the total number of cards
    public static int GetTotalCardCount()
    {
        LoadCardsFromJSON(); // Ensure cards are loaded before accessing
        return cards?.Count ?? 0;
    }

    // Static method to get a random card
    public static CardConfig GetRandomCard()
    {
        LoadCardsFromJSON(); // Ensure cards are loaded before accessing

        if (cards != null && cards.Count > 0)
        {
            int randomIndex = Random.Range(0, cards.Count);
            return cards[randomIndex];
        }

        Debug.LogError("No cards available.");
        return null;
    }

    // Add a new card
    public static void AddCard(CardConfig newCard)
    {
        LoadCardsFromJSON(); // Ensure cards are loaded before modifying

        cards.Add(newCard);
        Debug.Log("New card added: " + newCard.CardName);

        SaveCardsToJSON(); // Save updated cards back to JSON
    }
    // Function to delete a card by name
    public static void DeleteCardByName(string cardName)
    {
        LoadCardsFromJSON(); // Ensure cards are loaded before modifying

        if (cards == null || cards.Count == 0)
        {
            Debug.LogError("No cards available to delete.");
            return;
        }

        // Find the card by name
        CardConfig cardToRemove = cards.Find(card => card.CardName == cardName);

        if (cardToRemove != null)
        {
            cards.Remove(cardToRemove);
            Debug.Log($"Card '{cardName}' deleted successfully.");
            SaveCardsToJSON(); // Save changes to JSON
        }
        else
        {
            Debug.LogError($"Card with name '{cardName}' not found.");
        }
    }
}
