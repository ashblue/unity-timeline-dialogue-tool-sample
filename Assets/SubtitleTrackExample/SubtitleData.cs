using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class SubtitleDataPlayable : PlayableBehaviour {
    public string text = "A Subtitle";
    public Color color = Color.white;
}

[Serializable]
public class SubtitleData : PlayableAsset, ITimelineClipAsset {

    public SubtitleDataPlayable subtitleData = new SubtitleDataPlayable();

    // Create the runtime version of the clip, by creating a copy of the template
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go) {
        return ScriptPlayable<SubtitleDataPlayable>.Create(graph, subtitleData);
    }

    // Use this to tell the Timeline Editor what features this clip supports
    public ClipCaps clipCaps {
        get { return ClipCaps.Blending | ClipCaps.Extrapolation; }
    }
}
