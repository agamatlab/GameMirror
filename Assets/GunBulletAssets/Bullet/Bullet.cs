using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletParams bulletParams;

    public Bullet(BulletParams bulletParams)
    {
        this.bulletParams = bulletParams;
    }

    // Function to calculate acceleration (returns zero vector if no homing)
    public Vector3 GetAcceleration(Vector3 currentPosition)
    {
        if (bulletParams.homing && bulletParams.homingTarget != null)
        {
            Vector3 directionToTarget = (bulletParams.homingTarget.transform.position - currentPosition).normalized;
            float accelerationMagnitude = bulletParams.speed / bulletParams.mass; // Example calculation
            return directionToTarget * accelerationMagnitude;
        }
        return Vector3.zero;
    }

    // Function to update bullet properties (e.g., size, speed)
    public void UpdateBullet(Rigidbody2D rb)
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = 9;
        }
        else
        {
            rb.gravityScale = 7;
        }
        // Placeholder for updating bullet properties dynamically (if needed)
    }
}
    