using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class CoreComp : MonoBehaviour
    {
        protected Core _core;

        public virtual void Awake()
        {
            _core = GetComponentInParent<Core>();
            if(_core == null)
            {
                Debug.Log("Core isn't exist in " + transform.parent.name);
            }
            _core.AddComponent(this);
        }

        public virtual void LogicUpdate() { }

        public void Destroy()
        {
            Destroy(_core.transform.parent.gameObject);
        }
    }
}
