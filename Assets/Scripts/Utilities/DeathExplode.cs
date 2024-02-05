using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class DeathExplode : MonoBehaviour
    {
        
        public Event Event { get; private set; }

        private void Awake()
        {
            Event = GetComponent<Event>();
        }

        private void OnEnable()
        {
            Event.OnAnimationFinished += OnAnimationFinished;
        }

        private void OnDisable()
        {
            Event.OnAnimationFinished -= OnAnimationFinished;
        }

        private void OnAnimationFinished()
        {
            Destroy(gameObject);
        }
    }
}
