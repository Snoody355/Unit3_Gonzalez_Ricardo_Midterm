using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "New Weapon Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private string weaponName;
    [SerializeField] private float damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float firerate;

    public float GetFireRate() => firerate;

    public float GetDamage() => damage;

    public float GetBulletSpeed() => bulletSpeed;

    public string WeaponName => weaponName;
   
}
