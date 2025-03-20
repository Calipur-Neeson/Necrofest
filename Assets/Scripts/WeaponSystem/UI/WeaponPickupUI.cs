using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickupUI : MonoBehaviour
{
    [Header("CurrentWeapon")]
    public TextMeshProUGUI currentWeaponName;
    public TextMeshProUGUI currentWeaponDamage;
    public TextMeshProUGUI currentWeaponSpeed;
    public TextMeshProUGUI currentWeaponDistance;
    public Image currentWeaponImage;
    
    [Header("NewWeapon")]
    public TextMeshProUGUI newWeaponName;
    public TextMeshProUGUI newWeaponDamage;
    public TextMeshProUGUI newWeaponSpeed;
    public TextMeshProUGUI newWeaponDistance;
    public Image newWeaponImage;

    [Header("ImageLibrary")]
    public Sprite sword;
    public Sprite axe;
    public Sprite hammer;

    private Transform player;

    void Start()
    {
        player = Camera.main.transform; 
        gameObject.SetActive(false); 
        BaseWeapon weapon = GetComponentInParent<BaseWeapon>();
        newWeaponName.text = weapon.weaponData.weaponName;
        newWeaponDamage.text = weapon.weaponData.damage.ToString();
        newWeaponSpeed.text = (2.0f - weapon.weaponData.speed).ToString();
        newWeaponDistance.text = weapon.weaponData.distance.ToString();
        GetWeaponImage(newWeaponImage, weapon);

    }
    void Update()
    {
        //transform.LookAt(transform.position + (transform.position - player.position));
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }

    public void GetCurrentWeaponInfo()
    {
        GameObject rightHand = FindFirstObjectByType<_rightHandPosition>().gameObject;
        GameObject currentMeleeWeapon = rightHand.transform.GetChild(0).gameObject;
        BaseWeapon currentWeapon = currentMeleeWeapon.GetComponent<BaseWeapon>();
        currentWeaponName.text = currentWeapon.weaponData.weaponName;
        currentWeaponDamage.text = currentWeapon.weaponData.damage.ToString();
        currentWeaponSpeed.text = (2.0f - currentWeapon.weaponData.speed).ToString();
        currentWeaponDistance.text = currentWeapon.weaponData.distance.ToString();
        GetWeaponImage(currentWeaponImage, currentWeapon);
    }

    private void GetWeaponImage(Image image ,BaseWeapon bw)
    {
        if (bw.weaponData.weaponName == "Sword")
        { image.sprite = sword; }
        else if (bw.weaponData.weaponName == "Axe")
        { image.sprite = axe; }
        else if (bw.weaponData.weaponName == "Hammer")
        { image.sprite = hammer; }
    }
}
