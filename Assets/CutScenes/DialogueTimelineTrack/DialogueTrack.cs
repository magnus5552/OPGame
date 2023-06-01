using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0, 0, 255)]
[TrackBindingType(typeof(TMP_Text))]
[TrackClipType(typeof(DialogueClip))]
public class DialogueTrack : TrackAsset
{
    [SerializeField] public string BackImageName;
    
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        foreach (var clip in GetClips())
        {
            if (clip.asset is not DialogueClip dialogue) continue;
            clip.displayName = dialogue.template.Text;
        }
        
        return base.CreateTrackMixer(graph, go, inputCount);
    }
}
