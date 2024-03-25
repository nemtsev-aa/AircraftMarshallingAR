using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _arSessionOriginText;
    [SerializeField] private TextMeshProUGUI _arSessionPositionText;
    [SerializeField] private TextMeshProUGUI _arSessionRotationText;

    private Transform _arSessionOrigin;
    private Transform _arSession;
    
    public void Init(Transform arSessionOrigin, Transform arSession) {
        _arSessionOrigin = arSessionOrigin;
        _arSession = arSession;
    }

    private void Update() {
        if (_arSessionOrigin != null && _arSession != null) {
            _arSessionOriginText.text = $"ArSessionOrigin Position: {_arSessionOrigin.position}";
            _arSessionPositionText.text = $"ArSession Position: {_arSession.position}";
            _arSessionRotationText.text = $"ArSession Rotation: {_arSession.rotation}";
        }
    }
}
