using Unity.Cinemachine;
using UnityEngine;

public class CutSceneActivation : MonoBehaviour
{
    void Start()
    {

    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
    
        Destroy(this.gameObject, 0.02f);
    }
}
