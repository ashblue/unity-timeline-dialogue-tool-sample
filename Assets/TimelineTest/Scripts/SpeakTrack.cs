using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CleverCrow.TimelineTest {
    [TrackClipType(typeof(SpeakData))]
    [TrackBindingType(typeof(DialogueController))]
    public class SpeakTrack : TrackAsset {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount) {
            return ScriptPlayable<SpeakMixer>.Create(graph, inputCount);
        }
    }
}