using UnityEngine;

public class AlignToCursor : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    public Transform player;  // Reference to the player object for determining facing direction

    private Vector3 initialScale; // Store the initial scale of the object

    void Start()
    {
        // Assign the main camera if not set
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // Store the initial scale of the gun
        initialScale = transform.localScale;
    }

    void Update()
    {
        AlignWithCursor();
    }

    void AlignWithCursor()
    {
        // Get the cursor position in world space
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;

        Vector3 cursorWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Calculate the direction from the object to the cursor
        Vector3 direction = cursorWorldPosition - transform.position;

        // Calculate the angle and apply it to the object
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Check if the cursor is to the left or right of the player
        if (cursorWorldPosition.x < player.position.x)
        {
            // Flip the gun horizontally when the cursor is on the left
            transform.localScale = new Vector3(initialScale.x, -initialScale.y, initialScale.z);
        }
        else
        {
            // Keep the gun's original scale when the cursor is on the right
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }
    }
}
