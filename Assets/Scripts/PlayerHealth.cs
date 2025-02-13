using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private RectTransform healthContainer;
    [SerializeField] private GameObject healthUIPrefab;
    public int currentHealth = 3;
    private int maxHealth = 3;

    private List<GameObject> list = new List<GameObject>();
    private GameObject go;
    private void Start()
    {
        //for (int i = 0; i < heartBackground.Length; i++)
        //{ heartBackground[i].SetActive(false); }
        //for (int i = 0;i < heartImage.Length; i++)
        //{ heartImage[i].SetActive(false); }
        // Setup the health UI
       
        for (int i = 0; i < maxHealth; i++)
        {
            go = Instantiate(healthUIPrefab, healthContainer);
            list.Add(go.transform.GetChild(0).gameObject);
        }
    }
    public void PlayerGetHurt()
    {
        currentHealth--;
        if (currentHealth > 0)
        {
            list[currentHealth].SetActive(false);
        }
        else if (currentHealth == 0)
        {
            PlayerDie();
        }
    
    }
    private void PlayerDie()
    {
        //gameObject.SetActive(false);
        HealPlayer(3);
    }
    
    public void HealPlayer(int heal)
    {
        if (currentHealth < maxHealth && currentHealth + heal <= maxHealth)
        {
            int temp = 0;
            while (temp < heal)
            {
                list[currentHealth+temp].SetActive(true);
                temp++;
            }
            currentHealth += heal;
        }
        else if (currentHealth < maxHealth && currentHealth + heal > maxHealth)
        {
            for(int i = currentHealth-1;i < maxHealth;i++)
            {
                list[i].SetActive(true);
            }
        }
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
        for (int i = 0; i < currentHealth; i++)
        {
            if(!list[i].activeSelf)
            {
                list[i].SetActive(true);
            }
        }
    }
}
