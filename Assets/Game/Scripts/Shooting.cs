
using Unity.Cinemachine;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public static Shooting Instance;
    PlayerControlls player;
    [SerializeField] MoveStats moveStats;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform[] firePoint;
    [SerializeField] int maxBullets = 8;
    public int bulletsLeft;
    [SerializeField] float recoil = 0.08f;
    CinemachineImpulseSource impulseSource;
   
    


    Rigidbody2D m_rb;
    bool canShoot;
    public int bulletsFired = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        player = GetComponent<PlayerControlls>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
        m_rb = GetComponent<Rigidbody2D>();
        canShoot = false;

        bulletsLeft = maxBullets;

    }
    void Update()
    {
        RandomFirePoint();
        if (player.isGrounded)
        {
            bulletsLeft = maxBullets;
            bulletsFired = 0;
        }
    }

     int rand;
    void RandomFirePoint()
    {
        rand = Random.Range(0, firePoint.Length);
    }

    public void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && !player.isGrounded && bulletsLeft >=0 && bulletsFired <= maxBullets && player.isJumping)
        {
            
            bulletsFired++;
            bulletsLeft--;
            GameObject bulletTemp = Instantiate(bullet, firePoint[rand].position, bullet.transform.rotation);
            impulseSource.GenerateImpulse();
            Destroy(bulletTemp, 0.2f);

        }
        if (Input.GetKeyUp(KeyCode.Space) || player.isGrounded)
        {
            

        }
        Debug.Log(player.isGrounded + " ");
    }
   
    
}
