using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlatformUp : MonoBehaviour
{
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float acceleration = 8f;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    Vector3 target;



    public Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {   
        
        target = pointB.position;
        DirectionCalculation();
    }


    void Update()
    {
        
    }

    void FixedUpdate()
    {
        UpYouGo();
    }
    
     Vector2 direction;

    void DirectionCalculation()
    {
        direction = (target - transform.position).normalized;
    }
    void UpYouGo()
    {
        if (Vector3.Distance(transform.position, pointB.position) < 0.05f)
        {
            target = pointA.position;
            DirectionCalculation();
        }
        if (Vector3.Distance(transform.position, pointA.position) < 0.05f)
        {
            target = pointB.position;
            DirectionCalculation();
        }

        rb.linearVelocity = direction * maxSpeed;
        
    }

   
}
