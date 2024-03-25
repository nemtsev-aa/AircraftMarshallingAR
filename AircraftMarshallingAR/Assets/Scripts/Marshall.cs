using UnityEngine;

[RequireComponent(typeof(SoundSignalManager))]
public class Marshall : MonoBehaviour {
    public const string SignalIndex = "SignalIndex_int";

    private SoundSignalManager _soundManager;
    private Animator _animator;

    private void Awake() {
        _animator ??= GetComponentInChildren<Animator>();
        _soundManager ??= GetComponent<SoundSignalManager>();
    }

    public void ShowSignal(SignData data) {
        _animator.SetInteger(SignalIndex, data.Index);
        _soundManager.Play(data.Sound);
    }
}
