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
            //Base cards
            case "Vitality":
            {
                //base card player hp (3)
                break;
            }
            case "Mobility":
            {
                //base card player speed (100)
                break;
            }
            case "Strength":
            {
                //base card player dmg (100)
                break;
            }
            
            //Common cards
            case "Increased Strength":
            {
                //playerDamageIncrease (5%)
                break;
            }
            case "Increased Mobility":
            {
                //playerSpeedIncrease (5%)
                break;
            }
            case "Critical Hit!":
            {
                //playerCritChanceIncrease (1%)
                break;
            }
            case "Critical Block!":
            {
                //playerBlockChanceIncrease (1%)
                break;
            }
            case "Quick Swings":
            {
                //playerAttackSpeedIncrease (5%)
                break;
            }
            case "Strong Legs":
            {
                //playerJumpHeightIncrease (5%)
                break;
            }
            
            // Rare cards
            case "Quickdraw":
            {
                //Increase range damage after melee kill.
                /*
                 event(enemyKilledMelee)
                 {
                    while (Time.deltaTime =< Time.deltaTime + 5)
                    {
                        playerRangedDamageIncrease (20%)
                    }
                 }                  
                 */
                break;
            }
            case "Chain Swings":
            {
                
                //Chained melee hits deal extra dmg
                
                //EnableChainSwings();
                /*
                public void ChainSwings()
                {   
                 float comboTimer = 3f;
                 event(PlayerAttackMelee)
                    {
                        while (time.deltaTime => time.deltaTime + comboTimer)
                            {
                                playerMeleeDamageIncrease (10%)
                            }
                    }
                }
                 */
                break;
            }
            case "Skirmisher":
            {
                //After ranged attack next melee extra dmg
                //EnableSkirmisher();
                /*
                public void Skirmisher()
                {
                 event(PlayerAttackRange)
                 
                }
                 
                  
                 */
                break;
            }
            case "Triforce":
            {
                //
                break;
            }
        }
    }
}
