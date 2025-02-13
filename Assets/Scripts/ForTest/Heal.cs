using UnityEngine;

public class Heal : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.HealPlayer(1);
        }
    }
}
