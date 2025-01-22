using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAddCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CardConfig cardConfigTest1 = new CardConfig(), cardConfigTest2 = new CardConfig();
        
        cardConfigTest1.CardName = "Speedy";
        cardConfigTest1.CardDiscription = "Increases shooting speed by 10";
        cardConfigTest1.gunPropModifier.bulletShootingSpeed = 10;

        cardConfigTest2.CardName = "One shoot";
        cardConfigTest2.CardDiscription = "Increase damage by 100, only one shot per round";
        cardConfigTest2.gunPropModifier.bulletDamage = 100;
        cardConfigTest2.gunPropModifier.magazineSize = 0;


        CardUtility.AddCard(cardConfigTest1);
        CardUtility.AddCard(cardConfigTest2);
        Debug.Log("Added two cards");
    }

}
