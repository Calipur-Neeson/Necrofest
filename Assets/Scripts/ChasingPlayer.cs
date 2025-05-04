using UnityEngine;

namespace AG2187
{
    public class ChasingPlayer : MonoBehaviour
    {
        private Transform playerPos; // Reference to the player's transform
        public float speed = 5f; // Speed of the enemy
                                 //public float detectionRange = 10f; // Range within which the enemy detects the player
        public float attackRange = 2.0f;

        private Animator animator;

        private EnemyHealth enemyHealth;

        public float cooldown = 3f;
        private float currentTime = 0;
        private bool canAttack;
        public Color gizmoColor = Color.yellow;

        void OnDrawGizmosSelected()
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
        private void OnEnable()
        {
            enemyHealth.isDead=false;
            ResetAttack();
        }
        private void Start()
        {
            GameObject player = FindFirstObjectByType<VRPlayerHealth>().gameObject;
            playerPos = player.transform;

            animator = GetComponent<Animator>();
            enemyHealth = GetComponent<EnemyHealth>();
        }
        void Update()
        {
            if (currentTime <= 0)
            {
                canAttack = true;
                currentTime = cooldown;
            }
            if (!canAttack)
            {
                currentTime -= Time.deltaTime;
            }
            if (playerPos != null)
            {
                float distance = Vector3.Distance(transform.position, playerPos.position);

                if (!enemyHealth.isDead)
                {
                    if (distance <= attackRange && canAttack)
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
                //else if (enemyHealth.isDead)
                //{
                //    animator.SetBool("isAttacking", false);
                //    animator.SetBool("isWalking", false);
                //}
            }
        }
        public void ResetAttack()
        {
            canAttack = false;
        }
    } 
}
