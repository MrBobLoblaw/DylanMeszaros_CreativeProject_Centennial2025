using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{

    [Header("Movement")]
    public float speed = 10f;
    private Vector2 move;
    private Vector3 lastDirection = Vector3.forward;
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;

    [Header("Jumping")]
    public float jumpForce = 5f;
    private bool isGrounded;

    [Header("Slope Handling")]
    public float maxSlopeAngle = 45f;
    private bool onSlope = false;
    private Vector3 slopeNormal;
    public LayerMask groundLayer;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        //Debug.Log("MoveEvent");
    }

    public void OnJump(InputAction.CallbackContext context) // Handles jump input
    {
        if (context.performed && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            Debug.Log("Jumped!");
        }
    }

    void Update()
    {
        RotatePlayer();
        MovePlayer();
        CheckGrounded();

        //Debug.Log(move);
    }

    public void RotatePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y).normalized;

        if (movement.magnitude > 0.01f)
        {
            lastDirection = movement;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lastDirection), 1f);
        }
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y).normalized * speed;

        // Check if player is on a slope
        if (OnSlope() && isGrounded)
        {
            movement = Vector3.ProjectOnPlane(movement, slopeNormal);
        }

        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }

    bool OnSlope()
    {
        // Cast a downward ray to detect slope
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1.5f))
        {
            float angle = Vector3.Angle(Vector3.up, hit.normal);
            if (angle < maxSlopeAngle && angle > 0f)
            {
                slopeNormal = hit.normal;
                return true;
            }
        }
        return false;
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.15f, groundLayer);
    }
}
