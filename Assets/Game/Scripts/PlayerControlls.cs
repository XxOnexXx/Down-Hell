
using UnityEngine;


public class PlayerControlls : MonoBehaviour
{
    [SerializeField] MoveStats moveStats;
    [SerializeField] Color color;
    [SerializeField] float fireRate = 0.3f;
    [SerializeField] float maxVelocity = 10f;
    public bool isOnPlatform;
    Rigidbody2D platRb;

    bool canDoubleJump;
    [SerializeField] float maxJumps = 2;
    [SerializeField] float jumpUsed;
    public bool isJumping;
    float timer;
    float t = 0.2f;


    [Header("Collision Checks")]
    [SerializeField] public Transform groundCheckPos;
    [SerializeField] public Vector2 groundCheckSize;
    [SerializeField] public LayerMask isThisGround;

    [SerializeField] private Vector2 myGravity;

    PlatformUp platformUp;
    

    float moveInput;
    public bool isGrounded;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myGravity = new Vector2(0, -Physics2D.gravity.y);

    }
    void Start()
    {
        jumpUsed = maxJumps;
    }


    void Update()
    {  
        HandleJump();
        GroundCheck();

        timer += Time.deltaTime;

        if (isGrounded)
        {
            jumpUsed = maxJumps;
            isJumping = false;
        }
        

    }

    void FixedUpdate()
    {
        HandleMove();
        if (timer > fireRate)
        {
            Shooting.Instance.Shoot();
            timer = 0;
        }

    }

    void OnEnable()
    {

    }

    void HandleMove()
    {
        moveInput = 0;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1;
        }

        Vector2 targetVelocity;

        if (isOnPlatform)
        {
            targetVelocity = new Vector2(maxVelocity * moveStats.moveSpeed * moveInput + platRb.linearVelocity.x, rb.linearVelocity.y + platRb.linearVelocity.y);
        }

        else
        {
            targetVelocity = new Vector2(maxVelocity * moveStats.moveSpeed * moveInput, rb.linearVelocity.y);
        }
        
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, t);

    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpUsed--;
            isJumping = true;
            if (isGrounded) //|| jumpUsed >= 1)
            {

                rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveStats.jumpForce);
            }    
        }

        
        if (rb.linearVelocity.y < 0)
            {
                rb.linearVelocity -= myGravity * moveStats.fallMultiplier;
            }


    }

    public void GroundCheck()
    {
        isGrounded = Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0f, isThisGround);

    }

    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnPlatform = true;
            transform.SetParent(collision.transform);
            platRb = collision.rigidbody;
            rb.gravityScale = 2;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
        transform.SetParent(null);
        rb.gravityScale = 4;
        platRb = null;
        isOnPlatform = false;
        }
        
    }
}
