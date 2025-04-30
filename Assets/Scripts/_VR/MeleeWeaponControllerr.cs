using UnityEngine;

public class MeleeWeaponControllerr : MonoBehaviour
{
    private CapsuleCollider weaponCollider;
    public float activationSpeed = 1.5f;

    private Vector3 lastPosition;
    private float currentSpeed;
    AudioSource audioSource;
    public AudioClip swordSound;
    public AudioClip hitSound;

    void Start()
    {
        weaponCollider = GetComponent<CapsuleCollider>();
        lastPosition = transform.position;
        weaponCollider.isTrigger = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;
        currentSpeed = velocity.magnitude;

        if (currentSpeed > activationSpeed) 
        {
            weaponCollider.isTrigger = true;
        }
        else if (currentSpeed > 2.5f)
        {
            audioSource.clip = swordSound;
            audioSource.Play();
        }
        else { weaponCollider.isTrigger = false;}

        lastPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(hitSound);
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(200, "Melee");
            }
        }
    }
}
