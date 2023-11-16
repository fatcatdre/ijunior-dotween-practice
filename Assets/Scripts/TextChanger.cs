using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private Text _textField;
    [SerializeField] private string _replacementText;
    [SerializeField] private string _additionalText;
    [SerializeField] private string _hackedText;
    [SerializeField] private ScrambleMode _scrambleMode;
    [SerializeField] private float _interval;
    [SerializeField] private float _duration;
    [SerializeField] private LoopType _loopType;

    private void Awake()
    {
        StartTween();
    }

    private void StartTween()
    {
        Sequence textChange = DOTween.Sequence(_textField);
        textChange.AppendInterval(_interval);
        textChange.Append(_textField.DOText(_replacementText, _duration));
        textChange.Append(_textField.DOText(_additionalText, _duration).SetRelative());
        textChange.Append(_textField.DOText(_hackedText, _duration, scrambleMode: _scrambleMode));
        textChange.SetLoops(-1, _loopType);
    }
}
