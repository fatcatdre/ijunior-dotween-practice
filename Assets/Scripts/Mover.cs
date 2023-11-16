using UnityEngine;
using DG.Tweening;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _positionZ;
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
            .DOMoveZ(_positionZ, _duration)
            .SetEase(_ease)
            .SetLoops(-1, _loopType);
    }
}
