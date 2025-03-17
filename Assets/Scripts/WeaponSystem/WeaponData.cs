using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "Scriptable Objectsz/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float speed;
    public float distance;
    public float delay;
    public float animatorSpeed;
}
