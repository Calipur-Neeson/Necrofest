using UnityEngine;

namespace AG2187
{
    public class CriticalChain : EpicCards
    {
        private void Awake()
        {
            cardName = "Critical Chain";
            cardDescription = "Increase crit rate after critting, double CC till next crit";
        }
    } 
}
