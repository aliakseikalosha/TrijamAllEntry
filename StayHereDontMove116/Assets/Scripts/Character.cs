using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody body;
    [SerializeField] private LayerMask groundLayer;

    public Transform Transform => body.transform;

    private bool IsGrounded
    {
        get
        {
            //todo add more Raycast
            if (Physics.Raycast(body.transform.position, Vector3.down, 1.1f, groundLayer))
            {
                return true;
            }
            return false;
        }
    }

    public virtual void Move(Vector3 direction)
    {
        var velocity = moveSpeed * direction;
        velocity.y = body.velocity.y;
        body.velocity = velocity;
    }

    public virtual void Jump()
    {
        if (IsGrounded)
        {
            body.AddForce(Vector3.up * jumpForce);
        }
    }
}