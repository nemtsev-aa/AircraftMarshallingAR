using UnityEngine;

public class Bootstrapp : MonoBehaviour {
    [SerializeField] private SignDataConfig _config;

    [Header("AR Companents")]
    [SerializeField] private Transform _arSessionOrigin;
    [SerializeField] private Transform _arSession;

    [Header("Service")]
    [SerializeField] private PlaceObject _placeObject;

    [Header("UI Panels")]
    [SerializeField] private SignalsPanel _signsPanel;
    [SerializeField] private InfoPanel _infoPanel;

    private GameMediator _gameMediator;

    private void Start() {
        _signsPanel.Init(_config);
        _infoPanel.Init(_arSessionOrigin, _arSession);

        _gameMediator = new GameMediator(_signsPanel, _placeObject);
        _gameMediator.Init();
        _gameMediator.StartPlacing();
    }
}
