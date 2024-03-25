using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSignalManager : MonoBehaviour {
    private AudioSource _source;

    private void Awake() {
        _source ??= GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip) => _source.PlayOneShot(clip);
}