using System.Collections;
using UnityEngine;

namespace Game.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();

            //StartCoroutine(FadeOutIt());
        }

        private IEnumerator FadeOutIt()
        {
            yield return FadeOut(1f);
            print("Faded out");
            yield return FadeIn(2f);
            print("Faded in");
        }

        public IEnumerator FadeOut(float time)
        {
            while (canvasGroup.alpha != 1)
            {
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }
        }

        public IEnumerator FadeIn(float time)
        {
            while (canvasGroup.alpha != 0)
            {
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null;
            }
        }
    }
}
