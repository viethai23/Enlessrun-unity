using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Yuki.NPlayer;

namespace Yuki
{
    public class SpawnMap : MonoBehaviour
    {
        [SerializeField] private GameObject _leverPartStart;
        [SerializeField] private List<GameObject> _spawnParts = new List<GameObject>();
        [SerializeField] private Player _player;
        [SerializeField] private float _distanceBetweenSpawn = 50.0f;
        [SerializeField] private float _distanceBetweenDestroy = 50.0f;
        private Vector3 _lastPartPosition;
        private Queue<GameObject> _spawnedParts = new Queue<GameObject>();

        private void Awake()
        {
            _lastPartPosition = _leverPartStart.transform.Find("EndPart").position;
            _spawnedParts.Enqueue(_leverPartStart);
            _spawnParts.AddRange(Resources.LoadAll<GameObject>("Map"));
        }

        private void Update()
        {
            SpawnPart();
            DestroyPart();
        }

        private void SpawnPart()
        {
            if (_lastPartPosition.x - _player.transform.position.x < _distanceBetweenSpawn)
            {
                SpawnPart(_spawnParts[UnityEngine.Random.Range(0, _spawnParts.Count)]);
            }
        }

        private void DestroyPart()
        {
            if (_spawnedParts.Count > 0)
            {
                GameObject firstPartSpawned = _spawnedParts.Peek();
                if (_player.transform.position.x - firstPartSpawned.transform.position.x > _distanceBetweenDestroy)
                {
                    DestroyImmediate(firstPartSpawned);
                    _spawnedParts.Dequeue();
                }
            }
        }

        public void ResetPartEndPoint(Vector3 deltaPos)
        {
            _lastPartPosition = _lastPartPosition + deltaPos;
        }

        private void SpawnPart(GameObject part)
        {
            GameObject partSpawned = Instantiate(part, _lastPartPosition, Quaternion.identity);
            Transform ground = partSpawned.transform.Find("Grid/Ground");
            ground.gameObject.AddComponent<SpawnObject>();
            _spawnedParts.Enqueue(partSpawned);
            _lastPartPosition = partSpawned.transform.Find("EndPart").position;
        }

    }
}
