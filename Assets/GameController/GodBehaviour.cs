using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class GodBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public GunProperties player1_gun;
    public GunProperties player2_gun;
    public Transform PlayerData;

    void Start()
    {
        PlayerData = transform.Find("PlayerData");
        player1_gun = PlayerData.GetComponent<GameManager>().GunPropertiesP1;
        player2_gun = PlayerData.GetComponent<GameManager>().GunPropertiesP2;

    }

    void StartCardPicking(bool Player)
    {
        if (Player)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
