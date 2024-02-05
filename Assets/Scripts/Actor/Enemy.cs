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
        private Movement _movement; public Movement Movement => _movement;
        private MeleeAttack _meleeAttack; public MeleeAttack MeleeAttack => _meleeAttack;
        private RangeAttack _rangeAttack; public RangeAttack RangeAttack => _rangeAttack;


        //State
        public IdleState IdleState { get; private set; }
        public MoveState MoveState { get; private set; }
        public AttackMeleeState AttackMeleeState { get; private set; }
        public AttackRangeState AttackRangeState { get; private set; }
        public DeathState DeathState { get; private set; }
        public DetectingPlayerState DetectingPlayerState { get; private set; }
        public HitState HitState { get; private set; }

        public SpriteRenderer SpriteRenderer { get; private set; }

        public override void Awake()
        {
            base.Awake();

            SpriteRenderer = GetComponent<SpriteRenderer>();

            IdleState = new IdleState(this, "idle");
            MoveState = new MoveState(this, "move");
            AttackRangeState = new AttackRangeState(this, "attackRange");
            AttackMeleeState = new AttackMeleeState(this, "attackMelee");
            DeathState = new DeathState(this, "death");
            DetectingPlayerState = new DetectingPlayerState(this, "detectingPlayer");
            HitState = new HitState(this, "hit");
        }

        private void OnTakeDamage()
        {
            Debug.Log(FSM.CurrentState.GetType());
            if (FSM.CurrentState.GetType() != DetectingPlayerState.GetType() 
                && FSM.CurrentState.GetType() != AttackMeleeState.GetType()
                && FSM.CurrentState.GetType() != AttackRangeState.GetType())
            {
                FSM.ChangeState(HitState);
            }
            //FSM.ChangeState(HitState);
        }

        private void OnEnemyDie()
        {
            FSM.ChangeState(DeathState);
        }

        private void OnDisable()
        {
            _damageReceiver.OnTakeDamage -= OnTakeDamage;
            _stats.OnEnemyDie -= OnEnemyDie;
        }

        public override void Start()
        {
            base.Start();

            _damageReceiver = Core.GetCoreComponent<DamageReceiver>();
            _stats = Core.GetCoreComponent<Stats>();
            _playerDetecting = Core.GetCoreComponent<PlayerDetecting>();
            _movement = Core.GetCoreComponent<Movement>();
            _meleeAttack = Core.GetCoreComponent<MeleeAttack>();
            _rangeAttack = Core.GetCoreComponent<RangeAttack>();

            _damageReceiver.OnTakeDamage += OnTakeDamage;
            _stats.OnEnemyDie += OnEnemyDie;

            if (_data.CanMove)
            {
                FSM.Initialization(MoveState);
            }
            else
            {
                FSM.Initialization(IdleState);
            }
            
        }

        public void SetDangerousMark(bool status)
        {
            _dangerousMark.SetActive(status);
        }

    }
}
