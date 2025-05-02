using UnityEngine;
using AG2187;
public class HayGuyAttack : MonoBehaviour
{
    private GameObject laser;
    private bool isAttack;
    private Vector3 shotDirection;
    private void Start()
    {
        laser = gameObject.transform.GetChild(0).gameObject;
        laser.SetActive(false);
    }
    private void Update()
    {
        if (isAttack)
        {
            laser.transform.position -= shotDirection * 10.0f * Time.deltaTime;
        }
    }
    public void EnableAttack()
    {
        laser.SetActive(true);
        isAttack = true;
        shotDirection = transform.forward;
    }

    public void DisableAttack()
    {
        laser.SetActive(false);
        isAttack = false;
        laser.transform.localPosition = new Vector3(0, 6.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.PlayerGetHurt(this.gameObject);
        }
    }
}
