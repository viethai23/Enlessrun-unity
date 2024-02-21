using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Awake()
        {
            _spawnEnemies.AddRange(Resources.LoadAll<GameObject>("Enemy"));
            _spawnCollectables.AddRange(Resources.LoadAll<GameObject>("Collection"));

            TilemapCollider = GetComponent<CompositeCollider2D>();

            if(TilemapCollider != null)
            {
                _tilemapBound = TilemapCollider.bounds;
                _minXTilemapBound = _tilemapBound.min.x;
                _maxXTilemapBound = _tilemapBound.max.x;
            }

            SpawnObjectWithRandomNumber(_spawnEnemies);
            SpawnObjectWithRandomNumber(_spawnCollectables);
        }

        private void SpawnObjectWithRandomNumber(List<GameObject> spawnObject)
        {
            int objectToSpawn = Random.Range(1, 3);
            while (objectToSpawn > 0)
            {
                objectToSpawn--;
                SpawnObjects(spawnObject);
            }
        }

        private void SpawnObjects(List<GameObject> spawnObject)
        {
            GameObject objectToSpawn = spawnObject[Random.Range(0, spawnObject.Count)];
            Vector2 positionToSpawn = new Vector2(Random.Range(_minXTilemapBound, _maxXTilemapBound), objectToSpawn.transform.position.y);
            GameObject obj = Instantiate(objectToSpawn, positionToSpawn, Quaternion.identity);
            obj.transform.parent = this.transform;

            int tryNum = 0;
            while(tryNum < 10)
            {
                tryNum++;
                if(!CheckObjectPosition(obj))
                {
                    positionToSpawn = new Vector2(Random.Range(_minXTilemapBound, _maxXTilemapBound), objectToSpawn.transform.position.y);
                    obj.transform.position = positionToSpawn;
                }
                else
                {
                    break;
                }
            }
        }

        private bool CheckObjectPosition(GameObject obj)
        {
            Collider2D objCollider = obj.GetComponent<Collider2D>();
            Bounds objBounds = objCollider.bounds;

            float minObjX = objBounds.min.x;
            float maxObjX = objBounds.max.x;

            if(minObjX <= _minXTilemapBound + 2 || maxObjX >= _maxXTilemapBound - 2)
            {
                return false;
            }

            Physics2D.IgnoreCollision(objCollider, TilemapCollider);

            Collider2D[] collisions = Physics2D.OverlapBoxAll(objCollider.bounds.center, objCollider.bounds.size, 0f);

            if(collisions.Length > 0)
            {
                return false;
            }

            return true;
        }

    }
}
