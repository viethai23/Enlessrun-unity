using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Yuki.NEnemy
{
    public class Enemy : Actor
    {
        [SerializeField] private EnemyData _data; public EnemyData Data => _data;
        [SerializeField] private GameObject _dangerousMark;

        //Core component
        private DamageReceiver _damageReceiver; public DamageReceiver DamageReceiver => _damageReceiver;
        private Stats _stats; public Stats Stats => _stats;
        private PlayerDetecting _playerDetecting; public PlayerDetecting PlayerDetecting => _playerDetecting;
        private MeleeAttack _meleeAttack; public MeleeAttack MeleeAttack => _meleeAttack;
        private RangeAttack _rangeAttack; public RangeAttack RangeAttack => _rangeAttack;
        private Sound _sound; public Sound Sound => _sound;


        //State
        public IdleState IdleState { get; private set; }
        public AttackMeleeState AttackMeleeState { get; private set; }
        public AttackRangeState AttackRangeState { get; private set; }
        public DeathState DeathState { get; private set; }
        public DetectingPlayerState DetectingPlayerState { get; private set; }
        public HitState HitState { get; private set; }

        public SpriteRenderer SpriteRenderer { get; private set; }

        private bool _isHit = false; public bool IsHit { get => _isHit; set => _isHit = value; }

        public override void Awake()
        {
            base.Awake();

            SpriteRenderer = GetComponent<SpriteRenderer>();

            IdleState = new IdleState(this, "idle");
            AttackRangeState = new AttackRangeState(this, "attackRange");
            AttackMeleeState = new AttackMeleeState(this, "attackMelee");
            DeathState = new DeathState(this, "death");
            DetectingPlayerState = new DetectingPlayerState(this, "detectingPlayer");
            HitState = new HitState(this, "hit");
        }

        private void OnTakeDamage()
        {
            if (FSM.CurrentState.GetType() != DetectingPlayerState.GetType() 
                && FSM.CurrentState.GetType() != AttackMeleeState.GetType()
                && FSM.CurrentState.GetType() != AttackRangeState.GetType()
                && FSM.CurrentState.GetType() != DeathState.GetType()
                && !_isHit)
            {
                FSM.ChangeState(HitState);
                _isHit = true;
            }
        }

        private void OnEnemyDie()
        {
            if(FSM.CurrentState.GetType() != DeathState.GetType())
            {
                FSM.ChangeState(DeathState);
                _stats.OnEnemyDie -= OnEnemyDie;
                _damageReceiver.OnTakeDamage -= OnTakeDamage;
            }
        }

        public override void Start()
        {
            base.Start();

            GetCoreComp();

            _damageReceiver.OnTakeDamage += OnTakeDamage;
            _stats.OnEnemyDie += OnEnemyDie;

            FSM.Initialization(IdleState);

        }

        public void SetDangerousMark(bool status)
        {
            _dangerousMark.SetActive(status);
        }

        private void GetCoreComp()
        {
            _damageReceiver = Core.GetCoreComponent<DamageReceiver>();
            _stats = Core.GetCoreComponent<Stats>();
            _playerDetecting = Core.GetCoreComponent<PlayerDetecting>();
            _meleeAttack = Core.GetCoreComponent<MeleeAttack>();
            _rangeAttack = Core.GetCoreComponent<RangeAttack>();
            _sound = Core.GetCoreComponent<Sound>();
        }
    }
}
