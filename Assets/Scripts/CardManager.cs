using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }
    public Card[] cardHand;

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
    cardHand = new Card[transform.childCount];

    //show cards on bottom left? 
    }
    
    
}