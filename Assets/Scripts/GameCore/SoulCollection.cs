using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Yuki.NPlayer;
using DG.Tweening;

namespace Yuki
{
    public class SoulCollection : MonoBehaviour
    {
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private AudioClip _collectSound;
        [SerializeField] private Transform _target;
        [SerializeField] private int _maxCoins;
        [SerializeField] private Ease _easeType;
        [SerializeField][Range(0.5f, 0.7f)] private float _minAnimDuration;
        [SerializeField][Range(0.7f, 1f)] private float _maxAnimDuration;

        public Action<int> OnUIChange;
        private Vector3 _targetPosition;
        private Queue<GameObject> _coinQueues = new Queue<GameObject>();


        private void Awake()
        {
            
            PrepareCoins();
        }

        private void PrepareCoins()
        {
            GameObject coin;
            for (int i = 0; i < _maxCoins; i++)
            {
                coin = Instantiate(_coinPrefab);
                coin.transform.position = Vector3.zero;
                coin.transform.parent = transform;
                coin.SetActive(false);
                _coinQueues.Enqueue(coin);
            }
        }

        private void Animate(Vector3 collectionCointPostion, int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                if(_coinQueues.Count > 0)
                {
                    GameObject coin = _coinQueues.Dequeue();
                    coin.SetActive(true);

                    coin.transform.position = collectionCointPostion;

                    UpdatePostionCoinImageInWordSpace();

                    CoinAnimate(coin);
                }
            }
        }

        private void UpdatePostionCoinImageInWordSpace()
        {
            var wordspaceTargetPosition = Camera.main.ScreenToWorldPoint(_target.position);
            _targetPosition = new Vector3(wordspaceTargetPosition.x, wordspaceTargetPosition.y, 0);
        }

        private void CoinAnimate(GameObject coin)
        {
            float duration = UnityEngine.Random.Range(_minAnimDuration, _maxAnimDuration);
            Tweener tweener = coin.transform.DOMove(_targetPosition, duration)
                        .SetEase(_easeType)
                        .OnComplete(() =>
                        {
                            coin.SetActive(false);
                            _coinQueues.Enqueue(coin);
                            OnUIChange?.Invoke(1);
                        });

            tweener.OnUpdate(() =>
            {
                UpdatePostionCoinImageInWordSpace();
            });
        }

        public void AddCoin(Vector3 collectionCointPostion, int amount)
        {
            SoundManager.Instance.PlayOneshotFXSound(_collectSound, 0.7f);

            Animate(collectionCointPostion, amount);
        }
    }
}
