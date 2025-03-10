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

    [HideInInspector] public bool isPayBack;
    private SphereCollider sphere;
    private bool isHurted = false;
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
        sphere = player.AddComponent<SphereCollider>();
        sphere.center = new Vector3 (0, 1, 0);
        sphere.radius = 0f;
        sphere.isTrigger = true;
        sphere.enabled = false;
    }

    private void Update()
    {
        if (isPayBack)
        {
            if (isHurted)
            {
                sphere.enabled = true;
                sphere.radius += 5.0f * Time.deltaTime;
                if (sphere.radius > 4.0f)
                {
                    isHurted = false ;
                    sphere.enabled = false ;
                    sphere.radius = 0f;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(100.0f, "");
            }
        }
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
                    attackManager.attackDamageMultiplier += 0.3f;
                    attackManager.rangeDamageMultiplier += 0.3f;
                    attackManager.ResetPlayerAttackAnimation();
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

            if (isPayBack)
            {
                isHurted = true;
            }
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
        attackManager.attackDamageMultiplier -= 0.3f;
        attackManager.rangeDamageMultiplier -= 0.3f;
        attackManager.ResetPlayerAttackAnimation();
    }
}
