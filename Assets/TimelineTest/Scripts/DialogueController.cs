using System.Collections;
using TMPro;
using UnityEngine;

namespace CleverCrow.TimelineTest {
    public class DialogueController : MonoBehaviour {
        private const float FADE_DURATION = 0.3f;
        private Coroutine _loop;
        private DisplayState _state;

        public CanvasGroup canvasGroup;
        public TextMeshProUGUI speakerOutput;
        public TextMeshProUGUI lineOutput;

        private enum DisplayState {
            Hiding,
            Showing
        }

        private void Awake () {
            ResetState();
        }

        private void OnEnable () {
            ResetState();
        }

        private void ResetState () {
            canvasGroup.alpha = 0;
            _state = DisplayState.Hiding;
        }

        public void Speak (string line, string speaker, float alpha) {
            Show();
            
            lineOutput.alpha = alpha;
            lineOutput.SetText(line);

            speakerOutput.alpha = alpha;
            speakerOutput.SetText(speaker);
        }

        public void Hide () {
            if (!Application.isPlaying  || _state == DisplayState.Hiding || !isActiveAndEnabled) return;
            StopLoop();
            _state = DisplayState.Hiding;
            _loop = StartCoroutine(FadeLoop(1, 0));
        }

        private void Show () {
            if (!Application.isPlaying || _state == DisplayState.Showing || !isActiveAndEnabled) return;
            StopLoop();
            _state = DisplayState.Showing;
            _loop = StartCoroutine(FadeLoop(0, 1));
        }
        
        private IEnumerator FadeLoop (float begin, float end) {
            var time = 0f;
            while (time < FADE_DURATION) {
                canvasGroup.alpha = Mathf.Lerp(begin, end, time / FADE_DURATION);
                time += Time.deltaTime;
                yield return null;
            }

            canvasGroup.alpha = end;
        }

        private void StopLoop () {
            if (_loop == null) return;
            
            StopCoroutine(_loop);
            _loop = null;
        }
    }
}