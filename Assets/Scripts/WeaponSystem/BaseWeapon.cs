using UnityEngine;

namespace AG2187
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        public WeaponData weaponData;
        private AttackManager attackManager;

        public bool isInHand;
        public float floatHeight = 0.2f;
        public float floatSpeed = 0.50f;
        public float rotationSpeed = 50.0f;

        protected virtual void start()
        {
            attackManager = FindFirstObjectByType<AttackManager>();
        }
        public virtual void Drop()
        {
            transform.SetParent(null);
            GetComponent<BoxCollider>().enabled = true;
            transform.rotation = Quaternion.LookRotation(Vector3.up, Vector3.right);
        }
        public virtual void HangingThere()
        {
            float newY = 2 + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }

        public virtual void SendMeleeInfo()
        {
            attackManager = FindFirstObjectByType<AttackManager>();
            attackManager.weaponName = weaponData.weaponName;
            attackManager.damage = weaponData.damage;
            attackManager.speed = weaponData.speed;
            attackManager.distance = weaponData.distance;
            attackManager.delay = weaponData.delay;
            attackManager.animatorSpeed = weaponData.animatorSpeed;
            attackManager.ResetPlayerAttackAnimation();
        }

        public virtual void SendRangeWeaponInfo()
        {
            attackManager = FindFirstObjectByType<AttackManager>();
            attackManager.tempRangeDamage = weaponData.damage;
            attackManager.ResetPlayerAttackAnimation();
        }
    } 
}