using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AG2187
{
    public class RangeWeaponPickupUI : MonoBehaviour
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
        public Sprite pistol;
        public Sprite musket;
        public Sprite blunderbuss;

        private Transform player;
        private BaseWeapon weapon;

        void Start()
        {
            player = Camera.main.transform;
            gameObject.SetActive(false);
            weapon = GetComponentInParent<BaseWeapon>();
            newWeaponName.text = weapon.weaponData.weaponName;
            newWeaponDamage.text = weapon.weaponData.damage.ToString();
            newWeaponSpeed.text = (2.0f - weapon.weaponData.speed).ToString();
            newWeaponDistance.text = weapon.weaponData.distance.ToString();
            GetWeaponImage(newWeaponImage, weapon);

        }
        void Update()
        {
            //transform.LookAt(transform.position + (transform.position - player.position));
            transform.position = weapon.gameObject.transform.position;
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0);
        }

        public void GetCurrentWeaponInfo()
        {
            GameObject leftHand = FindFirstObjectByType<_leftHandPosition>().gameObject;
            GameObject currentRangeWeapon = leftHand.transform.GetChild(0).gameObject;
            BaseWeapon currentWeapon = currentRangeWeapon.GetComponent<BaseWeapon>();
            currentWeaponName.text = currentWeapon.weaponData.weaponName;
            currentWeaponDamage.text = currentWeapon.weaponData.damage.ToString();
            currentWeaponSpeed.text = (2.0f - currentWeapon.weaponData.speed).ToString();
            currentWeaponDistance.text = currentWeapon.weaponData.distance.ToString();
            GetWeaponImage(currentWeaponImage, currentWeapon);
        }

        private void GetWeaponImage(Image image, BaseWeapon bw)
        {
            if (bw.weaponData.weaponName == "Pistol")
            { image.sprite = pistol; }
            else if (bw.weaponData.weaponName == "Musket")
            { image.sprite = musket; }
            else if (bw.weaponData.weaponName == "Blunderbuss")
            { image.sprite = blunderbuss; }
        }

    } 
}
