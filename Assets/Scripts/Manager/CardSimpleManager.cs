using System.Collections.Generic;
using UnityEngine;
using AG2187;
public class CardSimpleManager : MonoBehaviour
{
    public List<NormalCards> normalCards;
    public List<RareCards> rareCards;
    public List<EpicCards> epicCards;

    public static CardSimpleManager instance;

    public GameObject cardPanel;
    public PauseMenu pauseMenu;

    private BaseCards card;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.isPaused && cardPanel.activeSelf)
            { BackToGame(); }
        }
    }
    public void GetACard()
    {
        Debug.Log("I can get a card");
        Time.timeScale = 0f;
        pauseMenu.isPaused = true;
        cardPanel.SetActive(true);
        int x = Random.Range(0, 100);
        if (x <= 50)
        {
            int y = Random.Range(0, normalCards.Count);
            card = Instantiate(normalCards[y], cardPanel.transform.parent);
            //card.transform.SetAsFirstSibling();
            
        }
        else if (x > 50 && x <= 85)
        {
            int y = Random.Range(0, rareCards.Count);
            card = Instantiate(rareCards[y], cardPanel.transform.parent);
            rareCards.RemoveAt(y);
        }
        else
        {
            int y = Random.Range(0, epicCards.Count);
            card = Instantiate(epicCards[y], cardPanel.transform.parent);
            epicCards.RemoveAt(y);
        }
        card.transform.localPosition = Vector2.zero;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void BackToGame()
    {
        card.gameObject.SetActive(false);
        cardPanel.SetActive(false);
        Time.timeScale = 1.0f;
        card.ActivateCard(card.cardName);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
