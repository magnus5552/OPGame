using System;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class DialogueBehaviour : PlayableBehaviour
{
    [SerializeField]
    [TextArea(5, 10)]
    public string Text;

    private string _defaultText;
    private bool _isFirstFrameHappened;
    private TMP_Text _textMesh;
    
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (playerData is not TMP_Text textMesh)
            return;

        if (!_isFirstFrameHappened)
        {
            _defaultText = textMesh.text;
            _isFirstFrameHappened = true;
        }
        
        textMesh.text = Text;
        _textMesh = textMesh;
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        _isFirstFrameHappened = false;

        if (_textMesh == null) return;

        _textMesh.text = _defaultText;
        
        base.OnBehaviourPause(playable, info);
    }
}
