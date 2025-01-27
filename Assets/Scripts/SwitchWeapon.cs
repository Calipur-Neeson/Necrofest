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
    private PlayerController attack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attack = GetComponentInParent<PlayerController>();
        ActivateOnlyOne();
        SetWeaponInfo(0);
        
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
        }
    }

    private void SetWeaponInfo(int wNumber)
    {
        attack.attackDistance = distances[wNumber];
        attack.attackDelay = delays[wNumber];
        attack.attackSpeed = speeds[wNumber];
        attack.attackDamage = damages[wNumber];
        attack.animator.speed = animatorSpeeds[wNumber];
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
