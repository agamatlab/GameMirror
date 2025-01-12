using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Bullet bullet; // Instance of the Bullet class
    private Rigidbody2D rb; // Rigidbody reference
    private Camera mainCamera;


    void Start()
    {
        Debug.Log("BulletBehaviour Start");
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        // Initialize bullet properties
        bullet = new Bullet(Vector3.up, ricochetCount: 3, destroyOnCollision: true, speed: 7, mass: 1f, size: 0.5f, homing: false, homingTarget: null, damage: 10f);

        // Apply initial velocity
        rb.mass = bullet.mass;
        rb.velocity = bullet.initVelocityVector * bullet.speed;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

    }

    void FixedUpdate()
    {
        // Update homing logic in FixedUpdate for physics consistency
        if (bullet.homing && bullet.homingTarget != null)
        {
            Vector3? acceleration = bullet.GetAcceleration(transform.position);
            if (acceleration.HasValue)
            {
                rb.AddForce(acceleration.Value * rb.mass, ForceMode2D.Force);
            }
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

            if (bullet.ricochetCount > 0)
            {
                Ricochet(collision.contacts[0].normal, rb.velocity);
                bullet.ricochetCount--;
            }
            else if (bullet.destroyOnCollision)
            {
                Destroy(gameObject);
            }
        }
    }
    private void Ricochet(Vector2 collisionNormal, Vector2 LastVelocity)
    {
        /*// Calculate reflected direction
        Vector2 reflectedDirection = Vector2.Reflect(LastVelocity, collisionNormal);

        // Set the Rigidbody2D velocity to the reflected direction scaled by speed
        rb.velocity = reflectedDirection * bullet.speed;

        // Debug information
        Debug.Log("Reflected direction: " + reflectedDirection + " Collision Normal: " + collisionNormal + " Speed: " + rb.velocity.magnitude);*/
    }


    private void DamagePlayer(GameObject player)
    {
        Debug.Log($"Damaged player: {player.name} with {bullet.damage} damage.");
    }

    private bool IsVisibleFromCamera()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
               viewportPosition.y >= 0 && viewportPosition.y <= 1 &&
               viewportPosition.z > 0;
    }
}
