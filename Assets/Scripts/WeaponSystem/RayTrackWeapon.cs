using TMPro;
using UnityEngine;

public class RayTrackWeapon : MonoBehaviour
{
    private LayerMask mask;
    private Vector3 directionV;

    public GameObject textFindingWeapon;
    private void Start()
    {
        mask = LayerMask.GetMask("Weapon");
        directionV = new Vector3(0,0,1.0f);
        textFindingWeapon.SetActive(false);
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 2f, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2f, mask))
        {
            //Debug.Log("Press F to pick up weapon");
            textFindingWeapon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                BaseWeapon baseWeapon = hit.collider.gameObject.GetComponent<BaseWeapon>();
                baseWeapon.PickUpWeapon();
            }
        }
        else { textFindingWeapon.SetActive(false); }
    }
}
