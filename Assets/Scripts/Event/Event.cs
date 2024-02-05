using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class Event : MonoBehaviour
    {
        public event Action OnAnimationFinished;
        public event Action OnAttack;

        public void AnimationFinishedTrigger() => OnAnimationFinished?.Invoke();
        public void AttackTrigger() => OnAttack?.Invoke();
    }
}
