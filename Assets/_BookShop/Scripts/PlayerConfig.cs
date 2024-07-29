using UnityEngine;

namespace _BookShop.Scripts
{
    [CreateAssetMenu(fileName = "NewPlayer",menuName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public int Speed { get; private set; }
        [field: SerializeField] public int Money { get; private set; }
    }
}