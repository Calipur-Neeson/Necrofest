using UnityEngine;

public class Sword : BaseWeapon , IMeleeWeapon
{
    [SerializeField]private bool isInitialWeapon;
    private void Start()
    {
        if (isInitialWeapon)
        {
            EquipInRightHand();
        }
    }
    public void EquipInRightHand()
    {
        isInHand = true;
        GameObject rightHand = GameObject.FindFirstObjectByType<_rightHandPosition>().gameObject;
        transform.SetParent(rightHand.transform);
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localRotation = Quaternion.Euler(0, 0, 80);
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Destroy(rb);
        }
        GetComponent<BoxCollider>().enabled = false;
        base.SendMeleeInfo();
    }
    public override void Drop()
    {
        base.Drop();
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Destroy(rb);
        }
        isInHand = false;
    }
    private void Update()
    {
        if (!isInHand)
        {
            HangingThere();
        }
    }

}
