using UnityEngine;

public class CardEffect : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerhealth;
    private AttackManager attackManager;
    private GameObject weapon;
    private SwitchWeapon switchWeapon;
    private GameObject weaponTrigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        weapon = FindFirstObjectByType<SwitchWeapon>().gameObject;
        player = FindFirstObjectByType<PlayerController>().gameObject;
        weaponTrigger = FindFirstObjectByType<WeaponTrigger>().gameObject;

        playerhealth = player.GetComponent<PlayerHealth>();
        attackManager = player.GetComponent<AttackManager>();
        switchWeapon = weapon.GetComponent<SwitchWeapon>();

        if (player != null )
        {
            Debug.Log("Find Player");
        }
        if (weapon != null)
        {
            Debug.Log("Find Weapon");
        }
    }

    private void UpdateAttackRange()
    {
        attackManager.attackDistanceMultiplier *= 1.2f;
        attackManager.ResetPlayerAttackAnimation();
    }

    private void UpdateAttackDamage()
    {
        attackManager.attackDamageMultiplier *= 1.1f;
        attackManager.ResetPlayerAttackAnimation();
    }


    public void TriggerEffect(string name)
    {
        switch (name)
        {
            //Base cards
            case "Vitality":
            {
                    playerhealth.maxHealth = 3;               
                    playerhealth.IniHealth();    //base card player hp (3)
                    break;               
            }
            case "Mobility":
            {
                    attackManager.moveSpeed = 5.0f;
                    attackManager.ResetPlayerProperty();//base card player speed (100)
                    break;
            }
            case "Strength":
            {
                    attackManager.hitCriticalChance = 0f;
                    attackManager.hitDamageIncreaseRate = 0f;
                    attackManager.hitCriticalDamageIncresseRate = 0f;//base card player dmg (100)f
                    break;
            }

            //Common cards
            case "Triforce":
            {

                    attackManager.hitDamageIncreaseRate += 1;//(increase damage)//playerMovementSpeedIncrease(1%)
                    attackManager.moveSpeed *= 1.01f;
                    attackManager.ResetPlayerProperty(); //playerSpeedIncrease (1%)
                    switchWeapon.UpLevelWeapon(0.01f);
                    attackManager.ResetPlayerAttackAnimation();//playerAttackSpeedIncrease (1%)
                    break;
            }
            case "Increased Strength":
            {
                    attackManager.hitDamageIncreaseRate += 5;//playerDamageIncrease (5%)                
                    break;
            }
            case "Increased Mobility":
            {
                    attackManager.moveSpeed *= 1.05f;
                    attackManager.ResetPlayerProperty();//playerSpeedIncrease (5%)
                    break;
            }
            case "Critical Hit!":
            {
                    attackManager.hitCriticalChance += 1;//playerCritChanceIncrease (1%)
                    break;
            }
            case "Critical Block!":
            {
                    playerhealth.blockChance += 1;//playerBlockChanceIncrease (1%)
                    break;
            }
            case "Quick Swings":
            {
                    switchWeapon.UpLevelWeapon(0.05f);
                    attackManager.ResetPlayerAttackAnimation();//playerAttackSpeedIncrease (5%)
                    break;
            }
            case "Strong Legs":
            {
                    attackManager.jumpHeight *= 1.05f;
                    attackManager.ResetPlayerProperty();//playerJumpHeightIncrease (5%)
                    break;
            }

            // Rare cards
            case "Quickdraw":
            {
                    gameObject.AddComponent<EnemyKillTracker>();
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
                    //Invoke(nameof(UpdateAttackRange), 5f);
                    break;
            }
            case "Chain Swings":
            {
                    weaponTrigger.AddComponent<ChainSwings>();
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
                    {
                        NextPlayerMeleeDamageIncrease (20%)
                    }
                }
                 */
                break;
            }

            case "Blood Tribute":
            {
                //Deal extra damage after getting hit
                //EnableBloodTribute();
                /*
                 public void BloodTribute()
                 {         
                    public float tributeTime = 3f;                         
                    event(playerHit)
                    {
                        while (time.deltaTime >= time.deltaTime + tributeTime)
                        {
                            playerDamageIncrease (30%)
                        }
                    }
                 }
                 */
                break;
            }
            case "Eagle":
            {
                //Extra damage while in air
                //EnableEagle();
                /*
                public void Eagle()
                {
                    while (playerNotGrounded)
                    {
                        playerDamageIncrease (15%)
                    }
                }    
                */
                break;
            }
            case "Swoop In":
            {
                //Extra damage after dash
                //EnableSwoopIn();
                /*
                public void SwoopIn()
                {
                    public float swoopTime = 3f;
                    event (playerDash)
                        {
                        while (time.deltaTime =< time.deltaTime + swoopTime)
                            {
                                playerDamageIncrease(10%)
                            }
                        }
                }
                */
                break;
            }
            case "Crunchy Crits":
            {
                //Increases critical damage
                //playerCriticalDamageIncrease (20%)
                break;
            }
            case "Increased Vitality":
            {
                //Increase player health
                //playerHealthIncrease
                break;
            }
            case "Multitude Tap":
            {
                //Increase range attack charges per cooldown
                //playerRangeChargeIncrease (+1)
                break;
            }
            case "Speed Daemon":
            {
                //Increase damage based on movement speed
                //EnableSpeedDaemon();
                /*
                public void SpeedDaemon(float playerDamage)
                {
                    
                    float playerMS = Player.CurrentVelocity;
                    float speedDaemonBonus = playerDamage*1.05^(playerMS-90)/10;
                }  
                 */
                break;
            }

            //Epic upgrades
            case "Divine Dash":
            {
                //Immunity frames on dash
                //EnableDivinieDash();
                /*
                 
                 public void EnableDivineDash()
                 {
                    Animator animator = GetComponent<Animator>();
                    animator.enableDashIframes = true;
                 }
                 */
                
                //In dash animator add animation triggers that 
                //turns damageable script off and enable after dash finishes.
                break;
            }
            case "Payback":
            {
                //Deal big aoe dmg after being hit (100dmg)
                //EnablePayback();
                //Add a sphere trigger collider for player.
                /*
                public void Payback()
                public float paybackDamage = 100f;
                public GameObject trigger;
                event(playerHit)
                {
                    foreach (enemy in range of trigger)
                    {
                        damageEnemy();
                    }
                }
                 */
                break;
            }
            case "Ricochet":
            {
                //Range attack bounces to nearby 2 enemies in 2m range
                //EnableRicochet();
                /*
                public void Ricochet()
                {
                    
                    //get enemies in range of main target hit
                    Enemy[] enemyList = new Enemy[]();
                    forEeach (enemy in enemyList)
                    {
                        //get distance to player
                        //order closest from furthest to original target
                        for (int i = 0; i < 1; i++)
                        {
                            target = enemyList[i];
                            dealDamage(target);
                        }
                    }
                }
                
                */
                break;
            }
            case "Blood and Pain":
            {
                //Take one damage for extra damage
                //EnableBNP();
                /*
                public void BloodAndPain()
                {
                    damagePlayer(1);
                    playerDamageIncrease(); (25%)
                }
                */
                break;
            }
            case "Mercy Kill":
            {
                //Execute enemies on low hp
                //EnableMercyKill(); 
                //mercy kill is enabled on enemy script
                /*
                public void FixedUpdate()
                {
                   if (MercyKill == true) 
                        if (hp <= 0 || hp <= maxHp*0.1)
                            Destroy(this);
                }
                */
                break;
            }
            case "Deaths Door":
            {
                //Deal extra damage when hp is 1
                //EnableDeathsDoor();
                /*
                public void FixedUpdate()
                {
                    if (DeathsDoor == true)
                        if(hp = 1)
                            playerDamageIncrease(); (100%)
                }
                */
                break;
            }
            case "Death Cheat":
            {
                //Negate first death set back to 1 hp, remove card
                //EnableDeathCheat();
                /*
                public void DeathCheat()
                {
                        if (hp = 0)
                        {
                            hp = 1;
                            RemoveCard(DeathCheat);
                            DisableDeathCheat();
                        }
                }
                */
                break;
            }
            case "Critical Chain":
            {
                //Increase crit chance after critting till next crit
                //EnableCriticalChain();
                /*
                public void CriticalChain()
                {
                    event(playerCrits)
                    {
                    private bool CCActive;
                        if (CCActive = false)
                            {
                                playerCritChanceIncrease(); (double crit chance)
                                CCActive = true;
                            }
                        else
                            {
                                playerCritChanceDecrease(); (remove doubling)
                                CCActive = false;
                            }
                    }
                }
                */
                break;
            }
            case "Deadly Entrance":
            {
                //Increase damage for 10 sec after entering room
                //EnableDeadlyEntrance
                /*
                Public Void DeadlyEntrance()
                {
                    onTriggerEnter(roomEnterTrigger)
                    {
                        while (Time.time >= Time.time + 10)
                            playerDamageIncrease(); (double dmg)
                    }
                }
                 */
                break;
            }
            case "Parry":
            {
                //Deal damage when block triggers
                //EnableParry();
                /*
                Public Void Parry()
                {
                    event(PlayerBlocks)
                    {
                        //Enemy that attacked takes damage (weapon dmg)
                    }
                } 
                */
                break;
            }
        }
    
    
    }
}
