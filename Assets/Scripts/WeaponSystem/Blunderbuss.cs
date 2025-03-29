using UnityEngine;

public class Blunderbuss : BaseWeapon, IRangeWeapon
{
    private void Start()
    {
        Drop();
    }
    public void EquipInLeftHand()
    {
        isInHand = true;
        GameObject leftHand = GameObject.FindFirstObjectByType<_leftHandPosition>().gameObject;
        transform.SetParent(leftHand.transform);
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Destroy(rb);
        }
        GetComponent<BoxCollider>().enabled = false;
        base.SendRangeWeaponInfo();
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
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
    }
}
