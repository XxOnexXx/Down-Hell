using UnityEngine;

[CreateAssetMenu(fileName = "Menu", menuName = "Player Move Menu")]
public class MoveStats : ScriptableObject
{
    [Header("Movement")]
    [Range(0, 25)]
    [SerializeField] public float moveSpeed = 1.6f;

    [Header("Jump")]
    [Range(0, 30)]
    [SerializeField] public float jumpForce = 4f;
    [Range(0, 5)]
    [SerializeField] public float fallMultiplier = 2f;
    [Range(0, 75)]
    

    [Space]

    [Header("falling")]
    [SerializeField] public float maxFallingVelocity = 25f;
    


    


    


}
