using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private RectTransform healthContainer;
    [SerializeField] private GameObject healthUIPrefab;
    [HideInInspector] public int maxHealth = 3;
    [HideInInspector] public int currentHealth = 3;

    public int blockChance = 0;
    public bool ifBlock;

    private List<GameObject> list = new List<GameObject>();
    private GameObject go;
    [HideInInspector] public bool isBloodTribute = false;
    private bool isIncreased = false;
    private Coroutine resetBloodTribute;
    private GameObject player;
    private AttackManager attackManager;
    private void Start()
    {
        //currentHealth = maxHealth;
        //for (int i = 0; i < maxHealth; i++)
        //{
        //    go = Instantiate(healthUIPrefab, healthContainer);
        //    list.Add(go.transform.GetChild(0).gameObject);
        //}
        player = FindFirstObjectByType<PlayerController>().gameObject;
        attackManager = player.GetComponent<AttackManager>();
    }
    public void IniHealth()
    {
        currentHealth = maxHealth;
        for (int i = 0; i < maxHealth; i++)
        {
            go = Instantiate(healthUIPrefab, healthContainer);
            list.Add(go.transform.GetChild(0).gameObject);
        }
    }
    public void PlayerGetHurt()
    {
        int i = Random.Range(0, 100);
        if (i >= blockChance)
        {
            ifBlock = false;
            currentHealth--;
            if (isBloodTribute)
            {
                if (!isIncreased)
                {
                    attackManager.attackDamageMultiplier *= 1.3f;
                    attackManager.ResetPlayerAttackAnimation();
                    attackManager.rangeDamage *= 1.3f;
                    isIncreased = true;
                }
                if (resetBloodTribute != null)
                {
                    StopCoroutine(resetBloodTribute);
                }
                resetBloodTribute = StartCoroutine(IncreaseDamage());
            }
            if(currentHealth <= 0)
            {
                PlayerDie();
            }
            UpdateHealthBar();
        }
        else { ifBlock = true; }
    }

    public void UpdateHealthBar()
    {
        for(int i = 0; i < maxHealth;i++)
        {
            list[i].SetActive(false);
        }
        for (int i = 0; i < currentHealth; i++)
        {
            list[i].gameObject.SetActive(true);
        }
    }

    private void PlayerDie()
    {
        HealPlayer(maxHealth - 1);
    }
    
    public void HealPlayer(int heal)
    {
        currentHealth += heal;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }
    public void IncreasePlayerHealthLimit(int plus)
    {
        currentHealth += plus;
        maxHealth += plus;
        for (int i = 0; i < plus; i++)
        {
            go = Instantiate(healthUIPrefab, healthContainer);
            go.transform.GetChild(0).gameObject.SetActive(false);
            list.Add(go.transform.GetChild(0).gameObject);
        }
        UpdateHealthBar();
    }

    private IEnumerator IncreaseDamage()
    {
        yield return new WaitForSeconds(3f);
        isIncreased = false;
        attackManager.attackDamageMultiplier /= 1.3f;
        attackManager.ResetPlayerAttackAnimation();
        attackManager.rangeDamage /= 1.3f;
    }
}
