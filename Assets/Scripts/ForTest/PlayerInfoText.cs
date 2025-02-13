using TMPro;
using UnityEngine;

public class PlayerInfoText : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    public GameObject player;


    private AttackManager attackManager;
    private PlayerHealth playerHealth;
    private PlayerController playerController;

    private void Start()
    {
        attackManager = player.GetComponent<AttackManager>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerController = player.GetComponent<PlayerController>();
    }
    private void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        textbox.text = $"Player HP: {playerHealth.currentHealth}\nMove Speed: {playerController.moveSpeed}\nJump Height: {attackManager.jumpHeight}\n================\nWeapon Damage: {playerController.attackDamage}\nDamage Increase: {attackManager.hitDamageIncreaseRate}%\nCritical Chance: {attackManager.hitCriticalChance}%\nCritical Damage Increase: {attackManager.hitCriticalDamageIncresseRate}%\n*Actual Damage: {attackManager.hitDamage}"; 
    }
}
