using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }

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
    void Update()
    {
        //list of cards owned
        Card[] cardHand = new []{new Card()};
        
        //show cards on bottom left? 
        

        
    }
    
    
}