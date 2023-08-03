using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace GJ
{
    public class RawTextureFade : MonoBehaviour
    {
        [SerializeField] private RawImage target;
        [SerializeField] private float fadeSeconds;


        public void SetAlpha(float alpha)
        {
            this.ChangeAlpha(alpha);
        }


        public void FadeIn()
        {
            this.StartCoroutine(this.FadeInCoroutine());
        }


        public void FadeOut()
        {
            this.StartCoroutine(this.FadeOutCoroutine());
        }


        private IEnumerator FadeInCoroutine()
        {
            var startTime = Time.time;
            var lateTime = 0f;

            while (lateTime < this.fadeSeconds)
            {
                lateTime = Time.time - startTime;
                this.ChangeAlpha(lateTime / this.fadeSeconds);
                yield return null;
            }

            this.ChangeAlpha(1);
            yield break;
        }


        private IEnumerator FadeOutCoroutine()
        {
            var startTime = Time.time;
            var lateTime = 0f;

            while (lateTime < this.fadeSeconds)
            {
                lateTime = Time.time - startTime;
                this.ChangeAlpha(1 - (lateTime / this.fadeSeconds));
                yield return null;
            }

            this.ChangeAlpha(0);
            yield break;
        }


        private void ChangeAlpha(float alpha)
        {
            var r = target.color.r;
            var g = target.color.g;
            var b = target.color.b;
            this.target.color = new Color(r, g, b, alpha);
        }
    }
}