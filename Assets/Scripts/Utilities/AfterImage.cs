using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class AfterImage : MonoBehaviour
    {
        [SerializeField]
        private float activeTime = 0.1f;
        private float timeActived;
        private float alpha;
        [SerializeField]
        private float alphaSet = 0.8f;
        private float mutiplierAlpha = 0.85f;


        private GameObject player;
        private SpriteRenderer SR;
        private SpriteRenderer playerSR;
        private Color color;

        private void OnEnable()
        {
            SR = GetComponent<SpriteRenderer>();
            player = GameObject.Find("Player");
            playerSR = player.GetComponent<SpriteRenderer>();

            alpha = alphaSet;
            SR.sprite = playerSR.sprite;
            transform.position = player.transform.position;
            transform.rotation = player.transform.rotation;
            timeActived = Time.time;
        }

        private void Update()
        {
            alpha *= mutiplierAlpha;
            color = new Color(1, 1, 1, alpha);
            SR.color = color;

            if (Time.time >= (timeActived + activeTime))
            {
                AfterImagePool.Instance.AddToPool(gameObject);
            }
        }
    }
}
