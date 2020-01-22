using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float ConstantMoveVelocity;

    public float JumpVelocity;

    public Transform GroundChecker;

    public float GroundRadius;

    public LayerMask GroundLayer;

    private Rigidbody2D rb;

    private bool isOnGround;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(ConstantMoveVelocity, rb.velocity.y);

        isOnGround = Physics2D.OverlapCircle(GroundChecker.position, GroundRadius, GroundLayer);

        if (isOnGround && Input.GetMouseButtonDown(0))
            rb.velocity += new Vector2(0, JumpVelocity);
    }
}
