using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Yuki.NPlayer
{
    public class UI : CoreComp
    {
        [SerializeField] private List<Sprite> _attackIconImages = new List<Sprite>();
        [SerializeField] private MultipleIconValueBarTool _healthBar;
        [SerializeField] private TMP_Text _coinValue;
        [SerializeField] private CooldownSkill _attack;
        [SerializeField] private CooldownSkill _dash;
        [SerializeField] private Image _attackIconImage;

        private void Start()
        {
            Init();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            CheckSkillColldown(ref _attack);
            CheckSkillColldown(ref _dash);
        }

        private void Init()
        {
            _attack.skillImage.fillAmount = 0;
            _dash.skillImage.fillAmount = 0;
            _attackIconImage.sprite = _attackIconImages[0];
        }

        public void SetCurrentHealth(float v)
        {
            _healthBar.SetNowValue(v);
        }

        public void SetMaxHealth(float v)
        {
            _healthBar.SetMaxValue(v);
        }

        public void SetCoinValue(float v)
        {
            _coinValue.SetText(v + "");
        }

        public void UseAttack(float skillCooldown)
        {
            UseSkill(ref _attack, skillCooldown);
        }

        public void UseDash(float skillCooldown)
        {
            UseSkill(ref _dash, skillCooldown);
        }

        private void UseSkill(ref CooldownSkill skill, float skillCooldown)
        {
            skill.skillCooldown = skillCooldown;
            skill.skillImage.fillAmount = 1;
            skill.isCooldown = true;
        }

        private void CheckSkillColldown(ref CooldownSkill skill)
        {
            if(skill.isCooldown)
            {
                skill.skillImage.fillAmount -= 1 / skill.skillCooldown * Time.deltaTime;

                if(skill.skillImage.fillAmount <= 0)
                {
                    skill.skillImage.fillAmount = 0;
                    skill.isCooldown = false;
                }
            }
        }

        public void ChangeIcon(int index)
        {
            _attackIconImage.sprite = _attackIconImages[index];
        }

    }
}
