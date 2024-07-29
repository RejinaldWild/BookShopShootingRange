using UnityEngine;

namespace _ShootingRange.Scripts
{
    [CreateAssetMenu(fileName = "NewPlayerSettings", menuName = "PlayerConfig")]
    public class PlayerConfig: ScriptableObject
    {
        [field:SerializeField] public float Sensitivity { get; private set; }
        [field:SerializeField] public float Speed { get; private set; }
    }
}