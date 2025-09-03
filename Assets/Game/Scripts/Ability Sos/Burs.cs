
using UnityEngine;

[CreateAssetMenu(fileName = "Burst", menuName = "Burst Menu")]
public class Burs : ScriptableObject
{
    [Header("Shooting")]
    [Range(0, 2f)]
    public float fireRate = 0.07f;
    [Range(15, 75)]
    public float firePower = 15f;

    public float recoil = 0.8f;


}
