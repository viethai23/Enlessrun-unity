using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Yuki.NPlayer;

namespace Yuki
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _spawnEnemies = new List<GameObject>();
        [SerializeField] private Transform _enemySpawnPos;
        [SerializeField] private Player _player;
        [SerializeField] private float _timeToSpawn;

        private void Awake()
        {
            
        }

    }
}
