
using UnityEngine;


public class BulletPhysics : MonoBehaviour
{
    [SerializeField] Burs burst;
    [SerializeField] GameObject bulletShell;
    [SerializeField] Transform collsionPos;
    [SerializeField] MoveStats moveStats;
    Rigidbody2D b_Rb;

    void Start()
    {
        b_Rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
        Rigidbody2D playerRb = FindFirstObjectByType<PlayerControlls>().GetComponent<Rigidbody2D>();
        b_Rb.linearVelocity = Vector2.down * burst.firePower + playerRb.linearVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Debug.Log(collision.gameObject.name);
            GameObject tempShells = Instantiate(bulletShell, collsionPos.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(tempShells, 0.2f);
        }
    }
}
