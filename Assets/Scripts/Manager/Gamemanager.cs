using UnityEngine;

namespace AG2187
{
    public class Gamemanager : MonoBehaviour
    {
        private CardEffect cardEffect;
        void Start()
        {
            cardEffect = gameObject.GetComponent<CardEffect>();
            cardEffect.TriggerEffect("Vitality");
            cardEffect.TriggerEffect("Mobility");
            cardEffect.TriggerEffect("Strength");
        }

    } 
}
