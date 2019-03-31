using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CleverCrow.TimelineTest {
    public class DynamicDialoguePlayback : MonoBehaviour {
        public PlayableDirector director;
        public PlayableAsset asset;

        [Tooltip("Dialogue box index corresponds to the track the dialogue box will be assigned to")]
        public List<DialogueController> dialogueBoxes;

        private void Start () {
            director.playableAsset = asset;
            var timelineAsset = (TimelineAsset)director.playableAsset;

            for (var i = 0; i < dialogueBoxes.Count; i++) {
                var outputs = timelineAsset.outputs.ToArray();
                var track = (TrackAsset)outputs[i].sourceObject;
                director.SetGenericBinding(track, dialogueBoxes[i]);
            }

            director.Play(asset);
        }
    }
}
