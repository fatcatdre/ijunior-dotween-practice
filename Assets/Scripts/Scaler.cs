using UnityEngine;
using DG.Tweening;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _scaleFactor;
    [SerializeField] private float _duration;
    [SerializeField] private Ease _ease;
    [SerializeField] private LoopType _loopType;

    private void Awake()
    {
        StartTween();
    }

    private void StartTween()
    {
        transform
            .DOScale(_scaleFactor, _duration)
            .SetEase(_ease)
            .SetLoops(-1, _loopType);
    }
}
