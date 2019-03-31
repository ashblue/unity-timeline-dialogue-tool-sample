using UnityEngine;
using UnityEngine.Playables;

namespace CleverCrow.TimelineTest {
    public class SpeakMixer : PlayableBehaviour {
        private DialogueController _dialogueCtrl;
        
        public override void ProcessFrame (Playable playable, FrameData info, object playerData) {
            _dialogueCtrl = playerData as DialogueController;
            if (_dialogueCtrl == null) return;

            string dialogue = null;
            string speaker = null;
            var alpha = 1f;

            var count = playable.GetInputCount();
            for (var i = 0; i < count; i++) {
                var input = playable.GetInput(i);
                var weight = playable.GetInputWeight(i);

                if (!input.IsValid() || input.GetPlayState() != PlayState.Playing || weight < 0.5) continue;
                
                var data = ((ScriptPlayable<SpeakDataPlayable>)input).GetBehaviour();
                if (data == null) continue;

                dialogue = data.dialogue;
                speaker = data.speaker;
                alpha = 2 * (Mathf.Max(0.5f, weight) - 0.5f);
            }

            if (Application.isPlaying && dialogue == null) {
                _dialogueCtrl.Hide();
                return;
            }
            
            _dialogueCtrl.Speak(dialogue, speaker, alpha);
        }

        public override void OnGraphStop (Playable playable) {
            if (_dialogueCtrl == null) return;
            _dialogueCtrl.Hide();
        }
    }
}