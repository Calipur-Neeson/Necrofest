using UnityEngine;

public class CriticalChance : MonoBehaviour
{
    private AttackManager attackManager;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        attackManager = player.GetComponent<AttackManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attackManager.hitCriticalChance += 5;
        }
    }
}
