using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shool : MonoBehaviour
{
    [SerializeField] private objectPool bulletsPool;
    [SerializeField] private List<WeaponData> inventory = new List<WeaponData>();
    [SerializeField] private WeaponData equippedweapon;
    [Header("Shooting Settings")]
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Camera myCamera;

public void Shootweapon() {
        PooledObject pooledObj = bulletsPool.RetrivePoolObject();
        Rigidbody projectileclone = pooledObj.GetRigidbody();
        projectileclone.position = weaponTip.position;
        projectileclone.rotation = weaponTip.rotation;
        projectileclone.AddForce(myCamera.transform.forward * equippedweapon.GetBulletSpeed(), ForceMode.Impulse);
        pooledObj.ResetPooledObject(4f);

    }



    public void ChangeWeapon(int index)
    {
        index = Mathf.Clamp(index, 0, inventory.Count - 1);
        equippedweapon = inventory[index];
        
    }
}
