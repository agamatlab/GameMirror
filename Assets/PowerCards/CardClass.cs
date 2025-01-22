using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClass
{
    // This class works with CardBehaviour

    public string CardName;
    //public uint CardID;
    //public int CardRarety;
    public GunProperties gunPropModifier;
    public string CardDiscription;
    public CardClass(string cardName, string cardDiscription, GunProperties gunPropModifier)
    {
        this.CardName = cardName;
        this.CardDiscription = cardDiscription;
        this.gunPropModifier = gunPropModifier;
    }



}
