using UnityEngine;

public class IncreaseBlockChance : MonoBehaviour
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
            playerHealth.blockChance += 10;
        }
    }
}
