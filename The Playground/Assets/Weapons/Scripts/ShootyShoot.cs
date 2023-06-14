using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootyShoot : MonoBehaviour
{
    public int weaponID;
    Inputs inputs;
    public GameObject projectile;
    public float fireRate, burstRPM;
    public float MultiShotSpreadX, MultiShotSpreadY, MultiShotSpreadZ;
    public int bulletsPerShot;
    public bool canShoot;

    GameObject pojectileSpawner;

    public bool BurstFire, SinlgeShot, FullAuto, multiShot;

    private void Awake()
    {
        pojectileSpawner = GameObject.FindGameObjectWithTag("PojSpawn");
        inputs = GameObject.FindGameObjectWithTag("Player").GetComponent<Inputs>();
        canShoot = true;
    }

    private void OnEnable()
    {
        canShoot = true;
    }
    private void Update()
    {
        if(!gameObject.GetComponent<WeaponPickUp>().onFloor)
        {
            if(inputs.shooting)
            {
                if(((weaponID == Inventory.slot1 && Inventory.slot_Active)|| (weaponID == Inventory.slot2 &! Inventory.slot_Active)) && canShoot)
                {
                    canShoot = false;
                    if(FullAuto)
                    {
                        StartCoroutine(RPMFullAuto());
                    }
                    if(BurstFire)
                    {
                        StartCoroutine(RPMBurst());
                    }
                    if(SinlgeShot)
                    {
                        inputs.shooting = false;
                        StartCoroutine(RPMSingle());
                    }
                    if(multiShot)
                    {
                        StartCoroutine(RPMMulti());
                    }
                }
            }
        }
        
    }

    IEnumerator RPMFullAuto()
    {
        Instantiate(projectile, pojectileSpawner.transform);
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
    IEnumerator RPMBurst()
    {
        for (int i = 0; i < bulletsPerShot; i++)
        {
            Instantiate(projectile, pojectileSpawner.transform);
            yield return new WaitForSeconds(burstRPM);
        }
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
    IEnumerator RPMSingle()
    {
        Instantiate(projectile, pojectileSpawner.transform);
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
    IEnumerator RPMMulti()
    {
        for (int i = 0; i < bulletsPerShot; i++)
        {
            Vector3 spread = new Vector3(Random.Range(-MultiShotSpreadX, MultiShotSpreadX), Random.Range(-MultiShotSpreadY, MultiShotSpreadY), Random.Range(-MultiShotSpreadZ, MultiShotSpreadZ));
            Instantiate(projectile, pojectileSpawner.transform.position + spread, pojectileSpawner.transform.rotation);
        }
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
