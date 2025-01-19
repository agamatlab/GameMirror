using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAddCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CardConfig cardConfigTest = new CardConfig();
        cardConfigTest.CardName = "Test Card";
        cardConfigTest.CardDiscription = "This is a test card";
        cardConfigTest.gunPropModifier.bulletShootingSpeed = 10;
        cardConfigTest.gunPropModifier.bulletsPerShoot = 1;
        CardUtility.AddCard(cardConfigTest);
        CardUtility.AddCard(cardConfigTest);
        Debug.Log("Added two cards");
    }

}
