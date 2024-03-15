using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour {
    [SerializeField] private Transform _arSessionOrigin;
    [SerializeField] private Transform _arSession;

    [SerializeField] private TextMeshProUGUI _arSessionOriginText;
    [SerializeField] private TextMeshProUGUI _arSessionPositionText;
    [SerializeField] private TextMeshProUGUI _arSessionRotationText;

    private void Update() {
        _arSessionOriginText.text = $"ArSessionOrigin Position: {_arSessionOrigin.position}";
        _arSessionPositionText.text = $"ArSession Position: {_arSession.position}";
        _arSessionRotationText.text = $"ArSession Rotation: {_arSession.rotation}";
    }
}
