using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SignDataConfig), menuName = "Configs")]
public class SignDataConfig : ScriptableObject {
    [field: SerializeField] public List<SignData> Signs { get; private set; }
}