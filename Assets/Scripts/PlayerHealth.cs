using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int initialHealth;
    [SerializeField] private RectTransform healthContainer;
    [SerializeField] private GameObject healthUIPrefab;
    private int currentHealth = 3;
    private int mixHealth = 3;
    
    public GameObject[] heartBackground;
    public GameObject[] heartImage;

    private void Start()
    {
        //for (int i = 0; i < heartBackground.Length; i++)
        //{ heartBackground[i].SetActive(false); }
        //for (int i = 0;i < heartImage.Length; i++)
        //{ heartImage[i].SetActive(false); }
        // Setup the health UI
        for (int i = 0; i < currentHealth; i++)
        {
            Instantiate(healthUIPrefab, healthContainer);
        }
        IncreasePlayerHealth(0);
    }
    public void PlayerGetHurt()
    {
       currentHealth--;
       heartImage[currentHealth-1].SetActive(false);
       if (currentHealth == 0)
       {
           PlayerDie();
       }
    
    }
    private void PlayerDie()
    {
        //gameObject.SetActive(false);
        HealPlayer(3);
    }
    
    private void HealPlayer(int heal)
    {
        currentHealth += heal;
        if (currentHealth <= mixHealth) { } 
        else
        {
            currentHealth = mixHealth;
        }
        for (int i = 0; i < currentHealth; i++)
        {
            if (!heartImage[i].activeSelf)
            {
                heartImage[i].SetActive(true);
            }
        }
    }
    public void IncreasePlayerHealth(int plus)
    {
        currentHealth += plus;
        mixHealth += plus;
        SetUI();
    }

    private void SetUI()
    {
        for (int i = 0; i < mixHealth; i++)
        {
            if (!heartBackground[i].activeSelf)
            {
                heartBackground[i].SetActive(true); 
            }
            
        }
        for (int i = 0; i < currentHealth; i++)
        {
            if (!heartImage[i].activeSelf)
            {
                heartImage[i].SetActive(true);
            }
        }
    }
}
