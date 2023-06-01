using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class DialogueClip : PlayableAsset, ITimelineClipAsset
{
    [SerializeField] 
    public DialogueBehaviour template = new();

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DialogueBehaviour>.Create(graph, template);
        playable.SetDuration(2);
        return playable;
    }

    public ClipCaps clipCaps => ClipCaps.None;
}
