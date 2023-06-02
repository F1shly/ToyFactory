using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootyShoot : MonoBehaviour
{
    public int enemyID;
    public GameObject self;
    public GameObject projectile;
    public float fireRate, burstRPM;
    public int burstNumber;
    public bool canShoot;

    public GameObject pojectileSpawner;

    public bool BurstFire, FullAuto;

    private void Awake()
    {
        canShoot = true;
    }

    private void OnEnable()
    {
        canShoot = true;
    }
    private void Update()
    {
            if (canShoot)
            {
                canShoot = false;
                if (FullAuto)
                {
                    StartCoroutine(RPMFullAuto());
                }
                if (BurstFire)
                {
                    StartCoroutine(RPMBurst());
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
        for (int i = 0; i < burstNumber; i++)
        {
            Instantiate(projectile, pojectileSpawner.transform);
            yield return new WaitForSeconds(burstRPM);
        }
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
