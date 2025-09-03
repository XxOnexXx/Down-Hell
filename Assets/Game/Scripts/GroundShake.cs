using System.Collections;
using TMPro;
using UnityEngine;

public class GroundShake : MonoBehaviour
{
    [SerializeField] float shakeIntensity;
    Vector3 initialPos;
    [SerializeField] float minGroundShake = -0.2f;
    [SerializeField] float maxGroundShake = 0.2f;

    [SerializeField] int healthPoints = 4;
    [SerializeField] int currentHealthPoints;
    public bool canBeDestoyed;

    void Start()
    {
        currentHealthPoints = healthPoints;
        initialPos = transform.position;
        canBeDestoyed = true;
    }


    void Update()
    {
        if (currentHealthPoints <= 0 && canBeDestoyed == true)
        {
            Destroy(this.gameObject);    
        }
    }

    Vector3 targetPos;
    Vector3 finalPos;

    IEnumerator Shake()
    {
        float direction = Vector3.Distance(initialPos, finalPos);
        Vector3 rand = new Vector3(Random.Range(minGroundShake, maxGroundShake), Random.Range(minGroundShake, maxGroundShake)) * shakeIntensity;
        finalPos = initialPos + rand;
        transform.position = finalPos;
        yield return new WaitForSeconds(0.2f);
        transform.position = initialPos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        BulletPhysics bullet = collision.gameObject.GetComponent<BulletPhysics>();
        if (bullet)
        {
            currentHealthPoints--;
            StartCoroutine(Shake());
        }
    }
}
