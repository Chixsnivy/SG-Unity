using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))] // Ensure a CapsuleCollider is attached
public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float mouseSensitivity = 100f; // Sensitivity for mouse look
    public float maxLookAngle = 80f; // Maximum angle the camera can look up or down

    private Rigidbody rb;
    private CapsuleCollider collider;
    private float xRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();

        // Configure Rigidbody
        rb.freezeRotation = true; // Prevent Rigidbody from rotating due to physics
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; // Better collision detection

        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Handle mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);

        transform.localRotation = Quaternion.Euler(xRotation, transform.localEulerAngles.y + mouseX, 0f);
    }

    void FixedUpdate()
    {
        // Handle movement
        float moveX = Input.GetAxis("Horizontal"); // A/D keys
        float moveZ = Input.GetAxis("Vertical");   // W/S keys

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        move = move.normalized * moveSpeed * Time.fixedDeltaTime;

        // Move the Rigidbody while respecting collisions
        rb.MovePosition(rb.position + move);
    }

    void OnDestroy()
    {
        // Unlock and show the cursor when the script is destroyed
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}