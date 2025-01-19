using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Bullet bullet; // Instance of the Bullet class
    private Rigidbody2D rb; // Rigidbody reference
    private Camera mainCamera;
    private BulletParams defaultBulletParams;
    private Transform pivot;

    public void Initialize(Bullet bullet)
    {
        this.bullet = bullet;
    }

    void Start()
    {
        Debug.Log("BulletBehaviour Start");
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        // Apply initial velocity
        // rb.mass = bullet.bulletParams.mass;
        // rb.velocity = bullet.bulletParams.initVelocityVector * bullet.bulletParams.speed;
        // rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        if (bullet.bulletParams.homing)
        {
            pivot = transform.GetChild(0);
            pivot.gameObject.SetActive(true);
        }
        else
        {
            pivot = transform.GetChild(0);
            pivot.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Debug.Log("Bullets speed : " + rb.velocity.magnitude);
        if (bullet.bulletParams.homing)
        {
            // Change cone rotation angle
            float pivotRotationAngle = Mathf.Atan2(rb.velocity.y, rb.velocity.x);
            pivot.rotation = Quaternion.Euler(0, 0, pivotRotationAngle * Mathf.Rad2Deg);
        }

        // Update homing logic in FixedUpdate for physics consistency
        if (bullet.bulletParams.homing && bullet.bulletParams.homingTarget != null)
        {
            Vector3 acceleration = bullet.GetAcceleration(transform.position);
            rb.AddForce(acceleration * rb.mass, ForceMode2D.Force);
        }

        // Check if outside camera bounds
        if (!IsVisibleFromCamera())
        {
            Destroy(gameObject);
        }

        // Update bullet properties if needed
        bullet.UpdateBullet();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter");

        if (collision.gameObject.CompareTag("Player"))
        {
            DamagePlayer(collision.gameObject);
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.layer == 6 /*Level layer*/)
        {
            Debug.Log("Touching grass");

            if (bullet.bulletParams.ricochetCount > 0)
            {
                //Ricochet(collision.contacts[0].normal, rb.velocity / 1.5f);
                bullet.bulletParams.ricochetCount--;
            }
            else if (bullet.bulletParams.destroyOnCollision)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Ricochet(Vector2 collisionNormal, Vector2 lastVelocity)
    {
        // Calculate reflected direction
        Vector2 reflectedDirection = Vector2.Reflect(lastVelocity, collisionNormal);

        // Set the Rigidbody2D velocity to the reflected direction scaled by speed
        rb.velocity = reflectedDirection * bullet.bulletParams.speed;

        // Debug information
        Debug.Log("Reflected direction: " + reflectedDirection + " Collision Normal: " + collisionNormal + " Speed: " + rb.velocity.magnitude);
    }

    private void DamagePlayer(GameObject player)
    {
        Debug.Log($"Damaged player: {player.name} with {bullet.bulletParams.damage} damage.");
    }

    private bool IsVisibleFromCamera()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
               viewportPosition.y >= 0 && viewportPosition.y <= 1 &&
               viewportPosition.z > 0;
    }
}
