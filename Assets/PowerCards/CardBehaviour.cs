using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;

public class CardBehaviour : MonoBehaviour
{
    public bool LeftCard; // 0 if Left
    public Vector2 InitialPosition;
    CardClass card;
    public float RotationFactor = 0.5f;
    TextMeshProUGUI cardDiscription, cardName;
    Transform canvas;
    private bool isDragging = false; // Track if the object is being dragged
    private Vector2 mouseOffset; // Store the offset between the mouse and the object
    private float returnSpeed = 5f; // Speed at which the object returns to its initial position
    Camera cam;

    // Start is called before the first frame update

    public void Initialize(/*string cardName, string cardDescription, GunProperties gunModifiers*/)
    {
        //card = new CardClass(cardName, cardDescription, gunModifiers);
    }

    public GunProperties GetGunProperties()
    {
        GunProperties gunProperties = card.gunPropModifier;
        return gunProperties;
    }

    void Start()
    {
        Debug.Log("Active");
        Camera cam = Camera.main;

        if (card == null)
        {
            CardConfig cardConfig = CardUtility.GetRandomCard();
            card = new CardClass(cardConfig.CardName, cardConfig.CardDiscription, cardConfig.gunPropModifier);
        }
        if(InitialPosition == new Vector2(0,0))
        {
            Debug.Log("Spawned at " + InitialPosition);
            InitialPosition = transform.position;
        }

        canvas = transform.GetChild(0).GetComponent<Transform>();
        cardDiscription = canvas.GetChild(0).GetComponent<TextMeshProUGUI>();
        cardName = canvas.GetChild(1).GetComponent<TextMeshProUGUI>();
        

        cardDiscription.text = card.CardDiscription;
        cardName.text = card.CardName;
    }
    void OnMouseDown()
    {
        Debug.Log("Pressing");
        // When the mouse is pressed on the object, start dragging
        isDragging = true;

        // Calculate the offset between the object's position and the mouse position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseOffset = (Vector2)transform.position - mousePosition;
    }
    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Follow the mouse position while dragging
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + mouseOffset;
        }
    }
    void OnMouseUp()
    {
        // When the mouse button is released, stop dragging
        isDragging = false;
        CardWasPicked(transform.position);

    }
    void Update()
    {

        RotateAsGoes(transform.position);
        if (!isDragging)
        {
            // Smoothly move the object back to its initial position
            transform.position = Vector2.Lerp(transform.position, InitialPosition, returnSpeed * Time.deltaTime);
        }
    }
    void CardWasPicked(Vector2 cur_position)
    {
        float x = Camera.main.WorldToViewportPoint(InitialPosition - cur_position).x;
        if ((LeftCard && x > 0.7f) || (!LeftCard && x < 0.2f))
        {
            Debug.Log("Card was picked");
            gameObject.SetActive(false);
        };
    }
    void RotateAsGoes(Vector2 cur_position)
    {
        float x = Camera.main.WorldToViewportPoint(InitialPosition - cur_position).x;
        Debug.Log("Rotate as goes : " + x);
        if ((LeftCard && x > 0.5f) || (!LeftCard && x < 0.5f))
        {
            transform.rotation = Quaternion.Euler(0, 0, x * 360 / 2 - 90);
        }
    }
}
