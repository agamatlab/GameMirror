using Mirror;
using Mirror.Examples.Tanks;
using System.Globalization;
using UnityEngine;


public class GunBehaviour : NetworkBehaviour
{
    // Gun properties struct
    public GunProperties gunProperties;

    // Private fields for cooldown and reload
    private float lastShootTime;
    private bool isReloading = false;

    // References
    private Transform firePoint;
    private Bullet bullet;
    public GameObject bulletPrefab;

    private void Start()
    {
        gunProperties.setDefault();

        firePoint = transform.GetChild(0);
        firePoint = transform.GetChild(0); // Assuming the fire point is the first child
    }

    void Update()
    {
        // Shooting with left mouse button
        if (Input.GetMouseButton(0) && !isReloading && Time.time >= lastShootTime + 0.2f)
        {
            Shoot();
        }

        // If no ammo
        if (gunProperties.bulletsInMagazine == 0)
        {
            Reload();
        }
    }

    [Command]
    public void Shoot()
    {
        if (gunProperties.bulletsInMagazine <= 0)
        {
            Debug.Log("No bullets left in magazine. Reload!");
            return;
        }

        lastShootTime = Time.time;

        // Simulate shooting multiple bullets per shot
        for (int i = 0; i < gunProperties.bulletsPerShoot; i++)
        {
            // Instantiate the bullet GameObject
            GameObject bulletObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            NetworkServer.Spawn(bulletObject);

            // Get the BulletBehaviour component
            BulletBehaviour bulletBehaviour = bulletObject.GetComponent<BulletBehaviour>();

            if (bulletBehaviour != null)
            {
                // Create a new BulletParams instance
                BulletParams bulletParams = new BulletParams
                {
                    ricochetCount = gunProperties.bulletRicochet,
                    destroyOnCollision = gunProperties.destroyOnCollision,
                    speed = gunProperties.bulletShootingSpeed,
                    mass = gunProperties.bulletMass,
                    size = gunProperties.bulletSize,
                    damage = gunProperties.bulletDamage,
                    homing = gunProperties.bulletHoming,
                    homingTarget = null, // Set this if needed
                    initPositionVector = firePoint.position,
                    initVelocityVector = GetBulletDirection() // Get initial direction
                };

                // Create a Bullet instance and pass it to the BulletBehaviour
                Bullet bulletInstance = new Bullet(bulletParams);
                bulletBehaviour.Initialize(bulletInstance);

                // Set the bullet's Rigidbody velocity
                /*Rigidbody2D rb = bulletObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = bulletParams.initVelocityVector * bulletParams.speed;
                    Debug.Log("Shooting with direction: " + rb.velocity);
                }*/
            }
            else
            {
                Debug.LogWarning("BulletBehaviour not found on instantiated bullet prefab.");
            }
        }

        // Decrease bullets in the magazine
        gunProperties.bulletsInMagazine--;
    }

    public void Reload()
    {
        if (isReloading || gunProperties.bulletsInMagazine == gunProperties.magazineSize)
        {
            Debug.Log("Reloading not needed.");
            return;
        }

        StartCoroutine(ReloadRoutine());
    }

    private System.Collections.IEnumerator ReloadRoutine()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(gunProperties.reloadTime);
        gunProperties.bulletsInMagazine = gunProperties.magazineSize;
        isReloading = false;
        Debug.Log("Reload complete.");
    }

    private Vector2 GetBulletDirection()
    {
        return firePoint.position - transform.position;
    }
}
