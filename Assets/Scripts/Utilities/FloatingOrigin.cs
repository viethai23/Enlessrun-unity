using Cinemachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Yuki
{
    public class FloatingOrigin : MonoBehaviour
    {
        [SerializeField] private float _threshold = 1000.0f;
        [SerializeField] private SpawnMap _spawnMap;

        void LateUpdate()
        {
            Vector2 cameraPosition = gameObject.transform.position;
            Vector3 newCameraPosition = new Vector3(cameraPosition.x, 0, 0);

            if (cameraPosition.magnitude > _threshold)
            {

                for (int z = 0; z < SceneManager.sceneCount; z++)
                {
                    foreach (GameObject g in SceneManager.GetSceneAt(z).GetRootGameObjects())
                    {
                        g.transform.position -= newCameraPosition;
                    }
                }
                Vector3 originDelta = Vector3.zero - newCameraPosition;
                _spawnMap.ResetPartEndPoint(originDelta);
            }
            
        }
    }
}
