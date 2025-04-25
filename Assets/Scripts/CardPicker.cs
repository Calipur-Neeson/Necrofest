using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class CardPicker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    CardManager manager = FindObjectOfType<CardManager>();
    
    void Start()
    {
        List<Card> commonList = manager.commonCards.ToList();
        List<Card> rareList = manager.rareCards.ToList();
        List<Card> epicList = manager.epicCards.ToList();
    }

    // Update is called once per frame
    void Update()
    {
        //roll rarities and random card from those
        Card card1;
        Card card2;
        Card card3;
        
        //ui stuff for card picker
        //show 3 clickable cards on the ui 

    }

    string RollRarity()
    {
        string rarity = "";
        float roll = Random.Range(1, 11);
        if (roll < 6.5f)
        {
            rarity = "common";
        }
        else if (roll < 6.5f && roll > 8.5f)
        {
            rarity = "rare";
        }
        else
        {
            rarity = "epic";
        }

        return rarity;
    }

    Card RandomCard(List<Card> commonList, List<Card> rareList, List<Card> epicList)
    {
        Card card = new Card();
        string rarity = RollRarity();
        if (rarity == "common")
        {
            int index = Random.Range(0,commonList.Count);
            card = commonList[index];
        }
        
        else if (rarity == "rare")
        {
            int index = Random.Range(0,rareList.Count);
            card = rareList[index];
        }
        
        else if (rarity == "epic")
        {
           int index =  Random.Range(0,epicList.Count);
           card = epicList[index];
        }
        
        return card;
    }
}