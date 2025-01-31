using UnityEngine;

public class ChasingPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float speed = 5f; // Speed of the enemy
    public float detectionRange = 10f; // Range within which the enemy detects the player

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= detectionRange)
            {
                // Move towards the player
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                // Rotate to face the player
                Vector3 direction = (player.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            }
        }
    }
}
