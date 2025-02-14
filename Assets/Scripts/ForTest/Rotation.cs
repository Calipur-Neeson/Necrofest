using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform target; 
    public float speed = 50f; 
    public Vector3 axis = Vector3.up;

    private PlayerHealth health;
    private void Start()
    {
        GameObject player = GameObject.Find("Player");
    }
    void Update()
    {
        if (target != null)
        {
            transform.RotateAround(target.position, axis, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.PlayerGetHurt();
        }   
    }
}
