using System;
using UnityEngine;

[Serializable]
public class SignData {
    [field: SerializeField] public int Index { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public AudioClip Sound { get; private set; }
}
