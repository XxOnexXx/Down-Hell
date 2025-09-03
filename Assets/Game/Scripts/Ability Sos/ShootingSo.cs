using UnityEngine;
using UnityEngine.Rendering.Universal;
[CreateAssetMenu(menuName = "Shooting parameteres")]
public class ShootingSo : ScriptableObject
{
    [SerializeField] public float shootFallSpeed = -5f;
    [SerializeField] public float shootFloatTimer;
    [SerializeField] public float shootFloatDuration = 0.2f;
}
