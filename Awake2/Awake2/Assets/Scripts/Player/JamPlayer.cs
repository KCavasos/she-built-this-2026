using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class JamPlayer : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius = 0.3f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody rb;
    private StarterAssetsInputs input;
    private bool isGrounded;

    private void Awake()
    {
        // Cache references
        rb = GetComponent<Rigidbody>();
        input = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        // 1. Detect Ground State
        isGrounded = Physics.CheckSphere(groundCheckPoint.position, groundCheckRadius, groundLayer);

        // 2. Read Jump Input from StarterAssetsInputs
        if (input.jump && isGrounded)
        {
            Jump();
        }
        
        MoveCharacter();
    }

    private void FixedUpdate()
    {
        // Handle physical movement inside FixedUpdate
//        MoveCharacter();
    }

    private void MoveCharacter()
    {
        // StarterAssetsInputs provides 'move' as a Vector2 (WASD / Left Stick)
        Vector2 moveInput = input.move;
        Debug.Log(moveInput);

        // Transform vector relative to the player's facing direction
        Vector3 moveDir = transform.forward * moveInput.y + transform.right * moveInput.x;
        
        // Calculate new target velocity while keeping current vertical velocity
        Vector3 targetVelocity = new Vector3(moveDir.x * moveSpeed, rb.linearVelocity.y, moveDir.z * moveSpeed);
        
        // Direct velocity assignment for snappy, responsive physics controls
        rb.linearVelocity = targetVelocity;
    }

    private void Jump()
    {
        // Reset vertical velocity prior to jumping for consistent jump heights
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        
        // Use VelocityChange to bypass mass factors entirely
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

        // Crucial: Reset the jump input flag so the character doesn't loop jumps
        input.jump = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheckPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
        }
    }
}