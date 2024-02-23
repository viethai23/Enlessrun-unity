using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Yuki
{
    [CustomEditor(typeof(TestWeapon))]
    public class TestWeaponEditor : Editor
    {
        private TestWeapon yourScript;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            TestWeapon yourScript = (TestWeapon)target;
            if (GUILayout.Button("Confirm Add Soul"))
            {
                yourScript.UpdateSoulValue();
            }

        }
    }
}
