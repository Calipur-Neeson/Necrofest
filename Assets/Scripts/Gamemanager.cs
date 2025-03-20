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

        //cardEffect.TriggerEffect("Blood Tribute");
        //cardEffect.TriggerEffect("Eagle");
        //cardEffect.TriggerEffect("Swoop In");
        //cardEffect.TriggerEffect("Skirmisher");
        //cardEffect.TriggerEffect("Multitude Tap");
        //cardEffect.TriggerEffect("Speed Daemon");
        //cardEffect.TriggerEffect("Divine Dash");
        //cardEffect.TriggerEffect("Payback");
    }

}
