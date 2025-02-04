using Unity.VisualScripting;
using UnityEngine;

public class EnemyApproach : MonoBehaviour
{
    private Vector3 playerLoc;
    public float moveSpeed = 2f;
    public float enemyHeight = 0.67f;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerLoc = player.transform.position;
        Vector3 targetLoc = new Vector3(playerLoc.x, enemyHeight, playerLoc.z);
        transform.position = Vector3.MoveTowards(transform.position, targetLoc, moveSpeed * Time.deltaTime);
    }
}
