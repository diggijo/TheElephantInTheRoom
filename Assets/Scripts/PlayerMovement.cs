using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private LayerMask canIJump;

    private float playerHeight = 2f;
    private float moveSpeed = 5f;
    private float jumpForce = 5f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        HandleJump();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleJump()
    {
        if (GameInput.Instance.isJumpPressed() && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void HandleMovement()
    {
        Vector2 input = GameInput.Instance.GetMovementVector();

        Vector3 move = orientation.right * input.x + orientation.forward * input.y;

        move = move.normalized;

        rb.linearVelocity = new Vector3(move.x * moveSpeed, rb.linearVelocity.y, move.z * moveSpeed);
    }

    private bool IsGrounded()
    {
        float rayLength = playerHeight / 2 + 0.2f;

        return Physics.Raycast(transform.position, Vector3.down, rayLength, canIJump);
    }

}
