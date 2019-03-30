using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SubtitleMixer : PlayableBehaviour {

    // Called each frame the mixer is active, after inputs are processed
    public override void ProcessFrame(Playable handle, FrameData info, object playerData) {
        var textObject = playerData as Text;
        if (textObject == null)
            return;

        string text = string.Empty;
        Color color = new Color(0, 0, 0, 0);

        var count = handle.GetInputCount();
        for (var i = 0; i < count; i++) {

            var inputHandle = handle.GetInput(i);
            var weight = handle.GetInputWeight(i);

            if (inputHandle.IsValid() &&
                inputHandle.GetPlayState() == PlayState.Playing &&
                weight > 0)
            {
                var data = ((ScriptPlayable<SubtitleDataPlayable>) inputHandle).GetBehaviour();
                if (data != null) {
                    // custom blend that is more suited for crossblends
                    if (weight > 0.5) {
                        text = data.text;
                        color.r = data.color.r;
                        color.g = data.color.g;
                        color.b = data.color.b;
                    }
                    color.a += data.color.a * 2 * (Mathf.Max(0.5f, weight) - 0.5f);
                }

            }
        }

        textObject.text = text;
        textObject.color = color;
    }
}
