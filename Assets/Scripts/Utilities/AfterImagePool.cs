using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class AfterImagePool : MonoBehaviour
    {
        [SerializeField]
        private GameObject afterImagePrefab;

        private Queue<GameObject> avaibleObjects = new Queue<GameObject>();

        public static AfterImagePool Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            GrowthPool();
        }

        private void GrowthPool()
        {
            for (var i = 0; i < 10; i++)
            {
                var instanceToAdd = Instantiate(afterImagePrefab);
                instanceToAdd.transform.SetParent(transform);
                AddToPool(instanceToAdd);
            }
        }

        public void AddToPool(GameObject instance)
        {
            instance.SetActive(false);
            avaibleObjects.Enqueue(instance);
        }

        public GameObject GetFromPool()
        {
            if (avaibleObjects.Count == 0)
            {
                GrowthPool();
            }

            var instance = avaibleObjects.Dequeue();
            instance.SetActive(true);
            return instance;
        }
    }
}
