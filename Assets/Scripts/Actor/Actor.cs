using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class Actor : MonoBehaviour
    {
        
        public Animator Anim { get; private set; }
        public FSM FSM { get; private set; }
        public Core Core { get; private set; }
        public Event Event { get; private set; }

        public virtual void Awake()
        {
            FSM = new FSM();
            Core = GetComponentInChildren<Core>();
        }

        public virtual void Start()
        {
            Anim = GetComponent<Animator>();
            Event = GetComponent<Event>();
        }

        public virtual void FixedUpdate()
        {
            FSM.CurrentState.PhysicUpdate();
        }

        public virtual void Update()
        {
            Core.LogicUpdate();
            FSM.CurrentState.LogicUpdate();
        }
    }
}
