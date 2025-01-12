using UnityEngine;

public class Bullet
{
    // Basic bullet properties
    public int ricochetCount;
    public bool destroyOnCollision = true;
    public float speed;
    public float mass;
    public float size;
    public float damage;

    public bool homing;
    public GameObject homingTarget;
    
    // Initial values
    public Vector3 initVelocityVector;

    public Bullet(Vector3 initVelocityVector, int ricochetCount, bool destroyOnCollision, float speed, float mass, float size, bool homing, GameObject homingTarget, float damage)
    {
        this.initVelocityVector = initVelocityVector;
        this.ricochetCount = ricochetCount;
        this.destroyOnCollision = destroyOnCollision;
        this.speed = speed;
        this.mass = mass;
        this.size = size;
        this.homing = homing;
        this.homingTarget = homingTarget;
        this.damage = damage;
    }

    // Function to calculate acceleration (returns nothing if no homing)
    public Vector3 GetAcceleration(Vector3 currentPosition)
    {
        if (homing && homingTarget != null)
        {
            Vector3 directionToTarget = (homingTarget.transform.position - currentPosition).normalized;
            float accelerationMagnitude = speed / mass; // Example calculation
            return directionToTarget * accelerationMagnitude;
        }
        return Vector3.zero;
    }

    // Function to update bullet properties (e.g., size, speed)
    public void UpdateBullet()
    {
        // Placeholder for updating bullet properties (e.g., dynamically change size or speed)
    }
}
