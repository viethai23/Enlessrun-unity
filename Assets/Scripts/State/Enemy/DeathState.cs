using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Yuki.NPlayer;

namespace Yuki.NEnemy
{
    public class DeathState : EnemyState
    {
        public DeathState(Actor actor, string animName) : base(actor, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Player.Instance.Collection.AddSoul(enemy.transform.position, enemy.Data.Value, enemy.transform.position);
            SoundManager.Instance.CreatePlayFXSound(enemy.Sound.Data.DeathFXSound, false);
            enemy.SetDangerousMark(false);

            enemy.Event.OnAnimationFinished += OnAnimationFinished;
        }

        private void OnAnimationFinished()
        {
            
            SoundManager.Instance.StopFXSound(enemy.Sound.Data.DeathFXSound);
            enemy.gameObject.SetActive(false);
        }

        public override void Exit()
        {
            base.Exit();

            enemy.Event.OnAnimationFinished -= OnAnimationFinished;
        }
    }
}
