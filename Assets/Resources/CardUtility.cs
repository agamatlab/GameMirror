using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class CardUtility
{
    private static CardCollection cardCollection = new CardCollection();

    // Ensure cards are loaded before accessing them
    private static void LoadCardsFromJSON()
    {
        if (cardCollection != null) return; // If already loaded, do nothing

        string path = "Assets/Resources/Cards.json";

        // Check if the file exists
        if (File.Exists(path))
        {
            // Read the JSON from the file
            //string json = File.ReadAllText(path);
            //Debug.Log("Text recovered " + json);

            //// Parse the JSON string into the CardCollection object
            //cardCollection. JsonUtility.FromJson<CardCollection>(json);
            //Debug.Log("File exist, trying to output it's size");
        }
        else
        {
            Debug.LogError("JSON file not found at path: " + path);
        }
    }

    // Static method to get a card by its index (order)
    public static CardConfig GetCardByIndex(int index)
    {
        LoadCardsFromJSON(); // Ensure cards are loaded before accessing

        if (cardCollection != null && index >= 0 && index < cardCollection.cards.Count)
        {
            return cardCollection.cards[index];
        }
        else
        {
            Debug.LogError("Card index out of range or no cards loaded.");
            return null;
        }
    }

    // Static method to get the total number of cards
    public static int GetTotalCardCount()
    {
        LoadCardsFromJSON(); // Ensure cards are loaded before accessing

        return cardCollection != null ? cardCollection.cards.Count : 0;
    }
    // Static method to get a random card
    public static CardConfig GetRandomCard()
    {
        LoadCardsFromJSON(); // Ensure cards are loaded before accessing

        if (cardCollection != null && cardCollection.cards.Count > 0)
        {
            int randomIndex = Random.Range(0, cardCollection.cards.Count);
            return cardCollection.cards[randomIndex];
        }
        else
        {
            Debug.LogError("No cards available.");
            return null;
        }
    }
    public static void AddCard(CardConfig newCard)
    {
        LoadCardsFromJSON(); // Ensure cards are loaded before modifying

        // Add the new card to the list
        cardCollection.cards.Add(newCard);

        // Convert the updated CardCollection back to JSON
        string updatedJson = JsonUtility.ToJson(cardCollection, true);

        // Write the updated JSON back to the file
        string path = "Assets/Resources/cards.json";  // Path to the JSON file
        File.WriteAllText(path, updatedJson);

        Debug.Log("New card added successfully and saved to the JSON file.");
    }
}
