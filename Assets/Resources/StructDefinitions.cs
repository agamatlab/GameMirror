using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct GunProperties
{
    public float bulletShootingSpeed;
    public int bulletsPerShoot;
    public int magazineSize;
    public int bulletsInMagazine;
    public float reloadTime;
    public bool bulletHoming;
    public int bulletRicochet;
    public bool destroyOnCollision;
    public float bulletSize;
    public float bulletAccuracy;
    public float bulletDamage;
    public float bulletMass;

    public void setToOnes()
    {
        bulletShootingSpeed = 1;
        bulletsPerShoot = 1;
        magazineSize = 1;
        bulletsInMagazine = 1;
        reloadTime = 1;
        bulletHoming = false;
        bulletRicochet = 1;
        destroyOnCollision = true;
        bulletSize = 1;
        bulletAccuracy = 1;
        bulletDamage = 1;
        bulletMass = 1;
    }

    public void setDefault()
    {

        bulletShootingSpeed = 40;
        bulletsPerShoot = 1;
        magazineSize = 3;
        bulletsInMagazine = 3;
        reloadTime = 1;
        bulletHoming = false;
        bulletRicochet = 0;
        destroyOnCollision = true;
        bulletSize = 1;
        bulletAccuracy = 1;
        bulletDamage = 5;
        bulletMass = 1;
    }
    public void addAnother(GunProperties gunProperties)
    {
        bulletShootingSpeed += gunProperties.bulletShootingSpeed;
        bulletsPerShoot += gunProperties.bulletsPerShoot;
        magazineSize += gunProperties.magazineSize;
        bulletsInMagazine += gunProperties.bulletsInMagazine;
        reloadTime += gunProperties.reloadTime;
        bulletHoming = bulletHoming || gunProperties.bulletHoming;
        bulletRicochet += gunProperties.bulletRicochet;
        destroyOnCollision = destroyOnCollision || gunProperties.destroyOnCollision;
        bulletSize += gunProperties.bulletSize;
        bulletAccuracy += gunProperties.bulletAccuracy;
        bulletDamage += gunProperties.bulletDamage;
        bulletMass += gunProperties.bulletMass;
    }

}
[System.Serializable]
public struct BulletParams
{
    // Basic bullet properties
    public int ricochetCount;
    public bool destroyOnCollision;
    public float speed;
    public float mass;
    public float size;
    public float damage;

    public bool homing;
    public GameObject homingTarget;

    // Initial values
    public Vector2 initPositionVector;
    public Vector2 initVelocityVector;
}
[System.Serializable]
public class CardConfig
{
    public string CardName;
    public string CardDiscription;
    public GunProperties gunPropModifier;

    public CardConfig(string cardName, string cardDiscription, GunProperties gunPropModifier)
    {
        CardName = cardName;
        CardDiscription = cardDiscription;
        this.gunPropModifier = gunPropModifier;
    }

    public CardConfig()
    {
        CardName = "Default Card";
        CardDiscription = "Default Card Description";
        gunPropModifier = new GunProperties();
        gunPropModifier.setToOnes();
    }
}
[System.Serializable]
public class CardCollection
{
    public List<CardConfig> cards; // List to hold all cards
    public CardCollection()
    {
        cards = new List<CardConfig>();
    }
}
[System.Serializable]
public class CardCollectionWrapper
{
    public List<CardConfig> cards;
}

