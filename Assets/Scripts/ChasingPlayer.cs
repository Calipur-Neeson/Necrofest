using UnityEngine;

public class ChasingPlayer : MonoBehaviour
{
    private Transform playerPos; // Reference to the player's transform
    public float speed = 5f; // Speed of the enemy
    //public float detectionRange = 10f; // Range within which the enemy detects the player
    public float attackRange = 2.0f;

    private Animator animator;
    
    private void Start()
    {
        GameObject player =FindFirstObjectByType<PlayerController>().gameObject;
        playerPos = player.transform;

        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (playerPos != null)
        {
            float distance = Vector3.Distance(transform.position, playerPos.position);
           
            if (distance <= attackRange) 
            {
                animator.SetBool("isAttacking", true);
                animator.SetBool("isWalking", false);
            }
            else
            {
                animator.SetBool("isAttacking", false);
                animator.SetBool("isWalking", true);
                transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);      
            }
        }
    }
}
