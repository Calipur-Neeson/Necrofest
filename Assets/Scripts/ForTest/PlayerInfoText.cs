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
        textbox.text = $"Player HP: {playerHealth.currentHealth}\nMove Speed: {playerController.moveSpeed}\nJump Height: {playerController.jumpHeight}\n================\nAttack Distance: {playerController.attackDistance}\nRange Damage: {attackManager.rangeDamage.ToString("F2")}\nWeapon Damage: {playerController.attackDamage.ToString("F2")}\nDamage Increase: {attackManager.hitDamageIncreaseRate}%\nCritical Chance: {attackManager.hitCriticalChance}%\nCritical Damage Increase: {attackManager.hitCriticalDamageIncresseRate}%\n*Actual Damage: {attackManager.hitDamage}\nBlockChance: {playerHealth.blockChance}%\nIs Blocked: {playerHealth.ifBlock}"; 
    }
}
