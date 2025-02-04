using UnityEngine;

public class CardEffect : MonoBehaviour
{   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  TriggerEffect(string name)
    {
        switch (name)
        {
            case "Increase damage":
            {
                //playerDamageMulti+1
                break;
            }
            case "Increase health":
            {
                //playerHealthIncrease
                break;
            }
            case "Increase speed":
            {
                //playerSpeedIncrease
                break;
            }
        }
    }
}
