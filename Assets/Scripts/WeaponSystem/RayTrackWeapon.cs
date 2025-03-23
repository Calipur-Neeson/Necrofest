using TMPro;
using UnityEngine;

public class RayTrackWeapon : MonoBehaviour
{
    private LayerMask maskM;
    private LayerMask maskR;
    private Vector3 directionV;

    //public GameObject textFindingWeapon;
    private void Start()
    {
        maskM = LayerMask.GetMask("MeleeWeapon");
        maskR = LayerMask.GetMask("RangeWeapon");
        directionV = new Vector3(0,0,1.0f);
        //textFindingWeapon.SetActive(false);
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 2f, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3.0f, maskM))
        {
            //Debug.Log("Press F to pick up weapon");
            //textFindingWeapon.SetActive(true);

            GameObject weaponPickupUI = hit.collider.gameObject.transform.GetChild(0).gameObject;
            WeaponPickupUI wui = weaponPickupUI.GetComponent<WeaponPickupUI>();
            wui.GetCurrentWeaponInfo();
            weaponPickupUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                //BaseWeapon baseWeapon = hit.collider.gameObject.GetComponent<BaseWeapon>();
                //baseWeapon.EquipInRightHand();
                GameObject rightHand = GameObject.FindFirstObjectByType<_rightHandPosition>().gameObject;
                if (rightHand.transform.childCount > 0)
                {
                    BaseWeapon baseWeapon = rightHand.transform.GetChild(0).GetComponent<BaseWeapon>();
                    baseWeapon.Drop();
                }

                IMeleeWeapon meleeWeapon = hit.collider.gameObject.GetComponent<IMeleeWeapon>();
                meleeWeapon.EquipInRightHand();
            }
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2f, maskR))
        {
            //Debug.Log("Press F to pick up weapon");
            //textFindingWeapon.SetActive(true);
            GameObject weaponPickupUI = hit.collider.gameObject.transform.GetChild(0).gameObject;
            RangeWeaponPickupUI wui = weaponPickupUI.GetComponent<RangeWeaponPickupUI>();
            wui.GetCurrentWeaponInfo();
            weaponPickupUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject leftHand = GameObject.FindFirstObjectByType<_leftHandPosition>().gameObject;
                if (leftHand.transform.childCount > 0)
                {
                    BaseWeapon baseWeapon = leftHand.transform.GetChild(0).GetComponent<BaseWeapon>();
                    baseWeapon.Drop();
                }
                IRangeWeapon rangeWeapon = hit.collider.gameObject.GetComponent<IRangeWeapon>();
                rangeWeapon.EquipInLeftHand();
            }
        }
        else 
        { 
            //textFindingWeapon.SetActive(false);
            WeaponPickupUI[] weaponUi = FindObjectsByType<WeaponPickupUI>(FindObjectsSortMode.None);
            foreach (var wu in weaponUi)
            {
                wu.gameObject.SetActive(false);
            }
            RangeWeaponPickupUI[] rangeweaponUi = FindObjectsByType<RangeWeaponPickupUI>(FindObjectsSortMode.None);
            foreach (var wu in rangeweaponUi)
            {
                wu.gameObject.SetActive(false);
            }
        }
    }
}
