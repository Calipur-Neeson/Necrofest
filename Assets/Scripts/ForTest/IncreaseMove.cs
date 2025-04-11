using UnityEngine;

public class IncreaseMove : MonoBehaviour
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
            attackManager.moveSpeed *= 1.1f;
            attackManager.ResetPlayerProperty();
        }
    }
}
