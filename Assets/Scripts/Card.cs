using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public CardRarity cardRarity;
    public Sprite sprite;
    public string cardText;

    private void OnEnable()
    {
        Card _card = this;
        //trigger effect when added to hand
        //CardEffect.TriggerEffect(cardName);
    }

    public enum CardRarity
    {
        common,
        rare,
        epic
    }
    
    
}
