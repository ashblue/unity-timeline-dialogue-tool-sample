using UnityEngine;
using UnityEngine.Playables;

namespace CleverCrow.TimelineTest {
    public class SpeakMixer : PlayableBehaviour {
        public override void ProcessFrame (Playable playable, FrameData info, object playerData) {
            var dialogueCtrl = playerData as DialogueController;
            if (dialogueCtrl == null) return;

            var dialogue = "";
            var speaker = "";

            var count = playable.GetInputCount();
            for (var i = 0; i < count; i++) {
                var input = playable.GetInput(i);
                var data = ((ScriptPlayable<SpeakDataPlayable>)input).GetBehaviour();
                
                if (!input.IsValid() || input.GetPlayState() != PlayState.Playing) continue;
                if (data == null) continue;

                dialogue = data.dialogue;
                speaker = data.speaker;
            }

            dialogueCtrl.Speak(dialogue, speaker);
        }

        public override void OnGraphStop (Playable playable) {
            base.OnGraphStop(playable);
            Debug.Log("stop");
        }
    }
}