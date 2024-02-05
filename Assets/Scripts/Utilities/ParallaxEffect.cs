using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuki
{
    public class ParallaxEffect : MonoBehaviour
    {
        [SerializeField] private Vector2 parallaxEffectMultiplier;
        [SerializeField] private bool infiniteHorizontal;
        [SerializeField] private bool infiniteVertical;
        private Transform cameraTranform;
        private Vector3 lastCameraPosition;
        private float textureUnitSizeX;
        private float textureUnitSizeY;

        private void Start()
        {
            cameraTranform = Camera.main.transform;
            lastCameraPosition = cameraTranform.position;
            Sprite sprite = GetComponent<SpriteRenderer>().sprite;
            Texture2D texture = sprite.texture;
            textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
            textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
        }

        private void LateUpdate()
        {
            Vector3 deltaMovement = cameraTranform.position - lastCameraPosition;
            transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
            lastCameraPosition = cameraTranform.position;

            if (infiniteHorizontal)
            {
                if (Mathf.Abs(cameraTranform.position.x - transform.position.x) >= textureUnitSizeX)
                {
                    float offsetPositionX = (cameraTranform.position.x - transform.position.x) % textureUnitSizeX;
                    transform.position = new Vector3(cameraTranform.position.x + offsetPositionX, transform.position.y);
                }
            }

            if (infiniteVertical)
            {
                if (Mathf.Abs(cameraTranform.position.y - transform.position.y) >= textureUnitSizeY)
                {
                    float offsetPositionY = (cameraTranform.position.y - transform.position.y) % textureUnitSizeY;
                    transform.position = new Vector3(cameraTranform.position.x, transform.position.y + offsetPositionY);
                }
            }

        }
    }
}

