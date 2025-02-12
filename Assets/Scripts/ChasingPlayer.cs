using UnityEngine;

public class ChasingPlayer : MonoBehaviour
{
    private Transform playerPos; // Reference to the player's transform
    public float speed = 5f; // Speed of the enemy
    public float detectionRange = 10f; // Range within which the enemy detects the player

    private void Start()
    {
        GameObject player =FindFirstObjectByType<PlayerController>().gameObject;
        playerPos = player.transform;
    }
    void Update()
    {
        if (playerPos != null)
        {
            float distance = Vector3.Distance(transform.position, playerPos.position);

            if (distance <= detectionRange)
            {
                // Move towards the player
                transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

                // Rotate to face the player
                Vector3 direction = (playerPos.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            }
        }
    }
}
