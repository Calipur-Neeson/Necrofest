using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform target; 
    public float speed = 50f; 
    public Vector3 axis = Vector3.up;

    private GameObject enemy;
    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        enemy = transform.GetChild(0).gameObject;
    }
    void Update()
    {
        if (target != null)
        {
            enemy.transform.RotateAround(target.position, axis, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit");
            VRPlayerHealth playerHealth = other.GetComponent<VRPlayerHealth>();
            playerHealth.PlayerGetHurt(this.gameObject);
        }   
    }
}
