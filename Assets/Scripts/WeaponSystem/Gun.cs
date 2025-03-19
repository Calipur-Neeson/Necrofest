using UnityEngine;

public class Gun : BaseWeapon , IRangeWeapon
{
    public override void DealDamage()
    {
        throw new System.NotImplementedException();
    }

    public void EquipInLeftHand()
    {
        GameObject leftHand = GameObject.FindFirstObjectByType<_leftHandPosition>().gameObject;
        transform.SetParent(leftHand.transform);
        transform.localPosition = new Vector3(0, -0.4f, -0.4f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Destroy(rb);
        }
    }
}
