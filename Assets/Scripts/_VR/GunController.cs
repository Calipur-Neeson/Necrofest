using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    [Header("RangeAttacking")]
    public Image rangeCoolDownImage;
    public float rangeCoolDownTime = 2f;
    AudioSource audioSource;
    public AudioClip gunSound;
    public ParticleSystem explosion;
    public ParticleSystem sparks;
    public GameObject bullet;
    private float rangeCurrentTime = 2f;
    private bool isRangeCooling = false;
    private bool isShoting;
    private SphereCollider shotCollider;

    //public TextMeshProUGUI bulletNumBox;
    public int shotNum { get; set; } = 1;
    private int currentShotNum = 0;

    private bool isGrabed;
    private XRBaseInteractor currentInteractor;

    public InputActionProperty triggerAction;

    [Header("Floating Settings")]
    public float floatAmplitude = 0.1f;
    public float floatFrequency = 1f;
    private Vector3 startPos;
    private void Start()
    {
        rangeCoolDownImage.fillAmount = 0f;
        rangeCurrentTime = rangeCoolDownTime;
        //bulletNumBox.text = shotNum.ToString();
        audioSource = GetComponent<AudioSource>();
        startPos = transform.position;
        shotCollider = bullet.GetComponentInChildren<SphereCollider>();
        shotCollider.enabled = false;
        
    }
    private void Update()
    {
        RangeStartCoolingDown();
        if (isGrabed)
        {
            if (triggerAction.action.WasPressedThisFrame())
            {
                //Debug.Log("shot!!");
                ShotGun();
            }
        }
        if (!isGrabed)
        {
            HangingThere();
        }
        if (isShoting)
        {
            shotCollider.center += new Vector3(0, 0, 1) * 80.0f * Time.deltaTime;
            shotCollider.radius += 6f * Time.deltaTime;
        }
    }
    private void HangingThere()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.up, Vector3.right);
        float newY = 1 + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
    private void ShotGun()
    {
        if (!isRangeCooling & currentShotNum < shotNum)
        {
            ActiveGunCollider();
            Invoke(nameof(PlayGunAudio), 0.1f);
            Invoke(nameof(ResetGunCollider), 0.4f);
            currentShotNum++;

            if (currentShotNum == shotNum)
            {
                rangeCoolDownImage.fillAmount = 1f;
                isRangeCooling = true;
                RangeStartCoolingDown();
            }
        }
    }
    private void ActiveGunCollider()
    {
        isShoting = true;
        shotCollider.enabled = true;
    }
    private void ResetGunCollider()
    {
        shotCollider.enabled = false;
        isShoting = false;
        shotCollider.center = Vector3.zero;
        shotCollider.radius = 0.1f;
    }

    private void PlayGunAudio()
    {
        audioSource.PlayOneShot(gunSound);
        explosion.Play();
        sparks.Play();
        ParticleSystem bulletEffect = bullet.GetComponent<ParticleSystem>();
        bulletEffect.Play();
    }
    private void RangeStartCoolingDown()
    {
        if (isRangeCooling & currentShotNum == shotNum)
        {
            rangeCurrentTime -= Time.deltaTime;
            rangeCoolDownImage.fillAmount = rangeCurrentTime / rangeCoolDownTime;
            if (rangeCurrentTime <= 0f)
            {
                isRangeCooling = false;
                rangeCurrentTime = rangeCoolDownTime;
                currentShotNum = 0;
            }
        }
    }

    public void OnSelectEnter()
    {
        isGrabed = true;
    }
    public void OnSelectExit()
    {
        startPos = transform.position;
        isGrabed = false;
    }
}
