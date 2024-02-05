using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NEnemy
{
    public class PlayerDetecting : CoreComp
    {
        [SerializeField] private Transform _detectPlayerCheck;
        [SerializeField] private Vector2 _detectPlayerCheckSize;
        [SerializeField] private LayerMask _whatIsDamageable;
        public event Action OnPlayerDetecting;
        public event Action OnPlayerDetectingFinished;
        private bool _isDetectedPlayer;

        private void Update()
        {
            DetectPlayer();
        }

        private void DetectPlayer()
        {
            if(!_isDetectedPlayer)
            {
                bool isPlayerInAttackRange = Physics2D.OverlapBox(_detectPlayerCheck.position, _detectPlayerCheckSize, 0, _whatIsDamageable);
                if(isPlayerInAttackRange)
                {
                    OnPlayerDetecting?.Invoke();
                    _isDetectedPlayer = true;
                }
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_detectPlayerCheck.position, _detectPlayerCheckSize);
        }
#endif

    }
}
