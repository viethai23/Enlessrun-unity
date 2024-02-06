using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NEnemy
{
    public class Stats : CoreComp
    {
        public event Action OnEnemyDie;

        [SerializeField] private float _maxHealth;
        public float _currentHealth;
        public float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = Mathf.Clamp(value, 0f, _maxHealth);
            }
        }

        private UIManager _uiController;

        private void Start()
        {
            _uiController = _core.GetCoreComponent<UIManager>();
            Init();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            _uiController.SetCurrentHealth(CurrentHealth);
            if (_currentHealth <= 0f)
            {
                OnEnemyDie?.Invoke();
            }
        }

        public void Init()
        {
            CurrentHealth = _maxHealth;
            _uiController.SetMaxHealth(_maxHealth);
        }
        public void IncreaseHealth(float amount) => CurrentHealth += amount;
        public void DecreaseHealth(float amount) => CurrentHealth -= amount;
    }
}
