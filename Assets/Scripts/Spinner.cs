using UnityEngine;
using DG.Tweening;

public class Spinner : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
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
            .DOLocalRotate(_rotation, _duration, RotateMode.FastBeyond360)
            .SetEase(_ease)
            .SetLoops(-1, _loopType);
    }
}
