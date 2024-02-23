using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class DestroyWhenFinished : MonoBehaviour
    {
        public Event Event { get; private set; }

        private void Awake()
        {
            Event = GetComponent<Event>();
            Event.OnAnimationFinished += OnAnimationFinished;
        }

        private void OnAnimationFinished()
        {
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            Event.OnAnimationFinished -= OnAnimationFinished;
        }
    }
}
