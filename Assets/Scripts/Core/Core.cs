using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class Core : MonoBehaviour
    {
        private List<CoreComp> _coreComps = new List<CoreComp>();

        public void LogicUpdate()
        {
            foreach (CoreComp coreComp in _coreComps)
            {
                coreComp.LogicUpdate();
            }
        }

        public void AddComponent(CoreComp coreComp)
        {
            if(!_coreComps.Contains(coreComp))
            {
                _coreComps.Add(coreComp);
            }
        }

        public T GetCoreComponent<T>() where T : CoreComp
        {
            var comp = _coreComps.OfType<T>().FirstOrDefault();
            if (comp == null)
            {
                Debug.LogWarning($"Component type {typeof(T)} isn't exist in {transform.parent.name}");
            }
            return comp;
        }

    }
}
