using System.Collections.Generic;
using UnityEngine;

public class VRPlayerHealth : MonoBehaviour
{
    [SerializeField] private RectTransform healthContainer;
    [SerializeField] private GameObject healthUIPrefab;
    [HideInInspector] public int maxHealth = 3;
    private int currentHealth = 3;

    private List<GameObject> list = new List<GameObject>();
    private GameObject go;
  
    private GameObject player;
    private void Start()
    {
        //player = FindFirstObjectByType<PlayerController>().gameObject;
        IniHealth();
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
    public void PlayerGetHurt(GameObject enemyObject)
    {
         currentHealth--;
         
         if (currentHealth <= 0)
         {
             PlayerDie();
         }
         UpdateHealthBar();        
    }

    public void UpdateHealthBar()
    {
        for (int i = 0; i < maxHealth; i++)
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
        //Die
        Debug.Log("You are dead");
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

    public void DecreasePlayerHealthLimit()
    {
        if (maxHealth > 1)
        {
            GameObject lastHealthUI = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            Destroy(lastHealthUI.transform.parent.gameObject);
        }
        currentHealth -= 1;
        maxHealth -= 1;
        UpdateHealthBar();
    } 
}
