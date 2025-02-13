using Unity.VisualScripting;
using UnityEngine;

public class FlyChasingPlayer : MonoBehaviour
{
    public Transform player; 
    public float speed = 5f; 
    public float detectionRange = 10f;
    public float hoveringHeight = 2.0f;

    private float currentDistance;
    private float minDistance = 1.5f;
    RaycastHit hit;

    private LayerMask groundLayer;
    private float additionalHeight = 0f;
    private Transform playerPos;

    private void Start()
    {
        GameObject player = FindFirstObjectByType<PlayerController>().gameObject;
        playerPos = player.transform;
        groundLayer = LayerMask.GetMask("Ground");
    }
    void Update()
    {
        currentDistance = Vector3.Distance(base.transform.position, player.position);
        if (currentDistance <= detectionRange)
        {
            ChasingMode();
            CheckHeight();
            float yOffset = Mathf.Sin(Time.time * 8.0f) * 0.8f + additionalHeight;
            transform.position = new Vector3(transform.position.x, transform.position.y + yOffset * Time.deltaTime, transform.position.z);
        }
    }

    private void ChasingMode()
    {
        if (player != null)
        {
            {
                // Move towards the player
                base.transform.position = Vector3.MoveTowards(base.transform.position, player.position, speed * Time.deltaTime);

                // Rotate to face the player
                Vector3 direction = (player.position - base.transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                base.transform.rotation = Quaternion.Slerp(base.transform.rotation, lookRotation, Time.deltaTime * 5f);

            }
        }
    }
    private void CheckHeight()
    {
        
        if (Physics.Raycast(transform.position, Vector3.down, out hit, hoveringHeight, groundLayer))
        {
            float groundDistance = hit.distance;
            if (groundDistance != minDistance)
            {
                //Debug.Log(groundDistance);
                additionalHeight += minDistance - groundDistance;
            }
            
            else {additionalHeight = 0; }
        }
    }
}
