using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CleverCrow.TimelineTest {
    [System.Serializable]
    public class SpeakDataPlayable : PlayableBehaviour {
        public string speaker = "Untitled";
        [TextArea]
        public string dialogue = "Dialogue goes here";
    }
    
    [System.Serializable]
    public class SpeakData : PlayableAsset, ITimelineClipAsset {
        public SpeakDataPlayable speakData = new SpeakDataPlayable();

        public override Playable CreatePlayable (PlayableGraph graph, GameObject owner) {
            return ScriptPlayable<SpeakDataPlayable>.Create(graph, speakData);
        }

        public ClipCaps clipCaps => ClipCaps.Blending;
    }
}