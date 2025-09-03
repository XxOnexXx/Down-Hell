
using UnityEngine;

[CreateAssetMenu(fileName = "Burst", menuName = "Burst Menu")]
public class Burs : ScriptableObject
{
    [Header("Shooting")]
    [Range(0, 2f)]
    public float fireRate = 0.07f;
    [Range(15, 75)]
    public float firePower = 15f;
    [Space]
    [Header("Recoil")]
    public float recoil = 0.8f;
    public float recoilMultiflier = 0.2f;
     [Space]
    [Range(0, 2)]
    public float destroyTime;
}
