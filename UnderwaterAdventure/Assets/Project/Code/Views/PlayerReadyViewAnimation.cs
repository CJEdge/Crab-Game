using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.View.Animation;
using UnityEngine.UI;

namespace Project.Views {
    public class PlayerReadyViewAnimation : MonoBehaviour, IViewAnimation {

        [SerializeField]
        private CanvasGroup canvasGroup;

        public IEnumerator IntroAnimation() {
            canvasGroup.alpha = 0;
            for (float i = 0; i < 1; i += Time.deltaTime) {
                canvasGroup.alpha = Mathf.Lerp(0, 1, i/1);
                yield return null;
            }
            canvasGroup.alpha = 1;
        }

        public IEnumerator OutroAnimation() {

            canvasGroup.alpha = 1;
            for (float i = 0; i < 1; i += Time.deltaTime) {
                canvasGroup.alpha = Mathf.Lerp(1, 0, i / 1);
                yield return null;
            }
            canvasGroup.alpha = 0;
        }
    }
}
