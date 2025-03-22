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
    public override void DealDamage()
    {
        throw new System.NotImplementedException();
    }

    
    public void EquipInRightHand()
    {
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

}
