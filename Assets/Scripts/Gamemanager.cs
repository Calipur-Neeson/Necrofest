using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private CardEffect cardEffect;
    void Start()
    {
        cardEffect = gameObject.GetComponent<CardEffect>();
        cardEffect.TriggerEffect("Vitality");
        cardEffect.TriggerEffect("Mobility");
        cardEffect.TriggerEffect("Strength");

        cardEffect.TriggerEffect("Quickdraw");
        //cardEffect.TriggerEffect("Strong Legs");
        //cardEffect.TriggerEffect("Critical Block!");
    }

}
