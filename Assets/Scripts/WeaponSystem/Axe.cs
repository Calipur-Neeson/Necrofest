using UnityEngine;

public class Axe : BaseWeapon , IMeleeWeapon
{
    public override void DealDamage()
    {
        throw new System.NotImplementedException();
    }

    public override void Equip()
    {
        throw new System.NotImplementedException();
    }
    public override void UnEquip()
    {
        throw new System.NotImplementedException();
    }

    

    public override void Switch()
    {
        throw new System.NotImplementedException();
    }

    public void EquipInRightHand()
    {
        GameObject rightHand = GameObject.FindFirstObjectByType<_rightHandPosition>().gameObject;
        transform.SetParent(rightHand.transform);
        transform.localPosition = new Vector3(0,0,0.36f);
        transform.localRotation = Quaternion.Euler(0,0,90);
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Destroy(rb);
        }
    }
}
