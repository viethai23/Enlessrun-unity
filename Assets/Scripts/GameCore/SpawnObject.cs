using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Yuki.NPlayer;

namespace Yuki
{
    public class SpawnObject : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _spawnEnemies = new List<GameObject>();
        [SerializeField] private List<GameObject> _spawnCollectables = new List<GameObject>();
        public CompositeCollider2D TilemapCollider { get; private set; }
        private Bounds _tilemapBound;
        private float _minXTilemapBound;
        private float _maxXTilemapBound;
        private float _rangeToSpawn;
        private float _offsetToSpawn = 5f;
        private int _numTryMax = 10;

        private void Awake()
        {
            _spawnEnemies.AddRange(Resources.LoadAll<GameObject>("Enemy"));
            _spawnCollectables.AddRange(Resources.LoadAll<GameObject>("Collection"));

            CalculateRangeToSpawn();

            TilemapCollider = GetComponent<CompositeCollider2D>();

            if(TilemapCollider != null)
            {
                _tilemapBound = TilemapCollider.bounds;
                _minXTilemapBound = _tilemapBound.min.x;
                _maxXTilemapBound = _tilemapBound.max.x;
            }
        }

        private void Start()
        {
            SpawnObjectWithRange();
        }

        private void SpawnObjectWithRange()
        {
            float startXSpawn = _minXTilemapBound;

            

            while(startXSpawn < _maxXTilemapBound)
            {
                if(CheckIfShouldSpawn())
                {
                    SpawnObjects(_spawnEnemies, startXSpawn, startXSpawn + _rangeToSpawn);
                }
                else
                {
                    SpawnObjects(_spawnCollectables, startXSpawn, startXSpawn + _rangeToSpawn);
                }


                startXSpawn += _rangeToSpawn + _offsetToSpawn;
            }
        }

        private void SpawnObjects(List<GameObject> spawnObject, float startXSpawn, float endXSpawn)
        {
            GameObject objectToSpawn = spawnObject[Random.Range(0, spawnObject.Count)];
            Vector2 positionToSpawn = new Vector2(Random.Range(startXSpawn, endXSpawn), objectToSpawn.transform.position.y);
            GameObject obj = Instantiate(objectToSpawn, positionToSpawn, Quaternion.identity);
            obj.transform.parent = this.transform;

            int tryNum = 0;
            while(tryNum < _numTryMax)
            {
                tryNum++;

                if (!CheckObjectPosition(obj))
                {
                    positionToSpawn = new Vector2(Random.Range(endXSpawn, endXSpawn), objectToSpawn.transform.position.y);
                    obj.transform.position = positionToSpawn;
                }
                else
                {
                    break;
                } 
            }

            if(!CheckObjectPosition(obj))
            {
                obj.SetActive(false);
            }
        }

        private bool CheckObjectPosition(GameObject obj)
        {
            Collider2D objCollider = obj.GetComponent<Collider2D>();
            Collider2D[] colliderInChildren = obj.GetComponentsInChildren<Collider2D>();
            Bounds objBounds = objCollider.bounds;

            float minObjX = objBounds.min.x;
            float maxObjX = objBounds.max.x;

            if(minObjX <= _minXTilemapBound || maxObjX >= _maxXTilemapBound)
            {
                return false;
            }

            Collider2D[] collisions = Physics2D.OverlapBoxAll(objCollider.bounds.center, objCollider.bounds.size, 0f);

            if(collisions.Length > 1 + colliderInChildren.Length)
            {
                return false;
            }

            return true;
        }

        private void CalculateRangeToSpawn()
        {
            _rangeToSpawn = Camera.main.orthographicSize;
        }

        private bool CheckIfShouldSpawn()
        {
            int spawn = Random.Range(0, 2);

            if(spawn == 1)
            {
                return true;
            }

            return false;
        }

    }
}
