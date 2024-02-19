using UnityEngine;

namespace Yuki
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Data/Enemy")]
    public class EnemyData : Data
    {
        [SerializeField] private int _value;
        [SerializeField] private bool _canRangeAttack;
        [SerializeField] private bool _canMeleeAttack;
        [SerializeField] private float _detectingPlayerTime;

        public int Value => _value;
        public bool CanRangeAttack => _canRangeAttack;  
        public bool CanMeleeAttack => _canMeleeAttack;
        public float DetectingPlayerTime => _detectingPlayerTime;
    }
}
