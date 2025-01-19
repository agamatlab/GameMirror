using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}

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

public class CardConfig
{
    public string CardName;
    public string CardDiscription;
    public GunProperties gunPropModifier;
}
public class CardCollection
{
    public List<CardConfig> cards; // List to hold all cards
}

public class StructDefinitions
{
    
}
