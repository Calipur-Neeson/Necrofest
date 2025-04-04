using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }
    public static List<Card> cardHand;
    public int commonCount;
    public int rareCount;
    public int epicCount;

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
        
    }

    // Update is called once per frame
    public void Update()
    {
    //list of cards owned
    List<string> cardNames = new List<string>();
    
    
    //count cards based on rarity
    foreach (Card card in cardHand)
    {
        if (card.cardRarity == Card.CardRarity.common)
            commonCount++;
        
        else if (card.cardRarity == Card.CardRarity.rare)
            rareCount++;
        else
            rareCount++;
    }
    
    
    }
    
    
}