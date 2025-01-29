using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPickBehaviour : MonoBehaviour
{
    public GunProperties gunPropertiesNew;
    bool FirstPlayerPicking = true;
    public GameObject CardPrefab;
    private GameObject Card1, Card2;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("CardPicking manager activated");
        // Create two cards 
        Card1 = Instantiate(CardPrefab, new Vector3(-4, 0, 0), Quaternion.identity);
        Card1.GetComponent<CardBehaviour>().LeftCard = true;
        Card1.transform.SetParent(transform);


        Card1 = Instantiate(CardPrefab, new Vector3(4, 0, 0), Quaternion.identity);
        Card1.GetComponent<CardBehaviour>().LeftCard = false;
        Card1.transform.SetParent(transform);

    }
    private void Update()
    {
        //Debug.Log("Card 1 position: " + Card1.transform.position);
        //Debug.Log("Card 2 position: " + Card2.transform.position); 
    }

}
