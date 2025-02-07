using UnityEngine;
using UnityEngine.InputSystem;
public class SwitchWeapon : MonoBehaviour
{
    [Header("Number of Weapons")]

    public GameObject[] weapons ;
    public float[] distances; 
    public float[] speeds; 
    public float[] delays;
    public float[] damages;
    public float[] animatorSpeeds;
    
    int tempCount = 0;
   
    [Header("Weapons Info (Don't Change)")]
    public float weaponSpeed;
    public float weaponDelay;
    public float weaponDamage;
    public float weaponDistance;
    public float attackAnimationSpeed;

    private AttackManager attackManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivateOnlyOne();
        SetWeaponInfo(0);
        attackManager = GetComponentInParent<AttackManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        { 
            if (tempCount < weapons.Length-1)
            {
                weapons[tempCount].SetActive(false);
                tempCount++;
                weapons[tempCount].SetActive(true);
                SetWeaponInfo(tempCount);
            }
            else
            {
                weapons[tempCount].SetActive(false);
                tempCount = 0;
                weapons[tempCount].SetActive(true);
                SetWeaponInfo(tempCount);
            }
            attackManager.ResetPlayerAttackAnimation();
        }
    }

    private void SetWeaponInfo(int wNumber)
    {
        weaponDistance = distances[wNumber];
        weaponDelay = delays[wNumber];
        weaponSpeed = speeds[wNumber];
        weaponDamage = damages[wNumber];
        attackAnimationSpeed = animatorSpeeds[wNumber];
    }

    private void ActivateOnlyOne()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] != null)
            {
                weapons[i].SetActive(false);
            }
        }
        weapons[0].SetActive(true);
    }
}
