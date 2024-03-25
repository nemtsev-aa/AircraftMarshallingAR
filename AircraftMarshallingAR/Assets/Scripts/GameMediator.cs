using System;
using UnityEngine;

public class GameMediator : IDisposable {
    private SignalsPanel _signalsPanel;
    private PlaceObject _placeObject;

    private Marshall _marshall;

    public GameMediator(SignalsPanel signalsPanel, PlaceObject placeObject) {
        _signalsPanel = signalsPanel;
        _placeObject = placeObject;
    }

    public void Init() {
        AddListeners();
    }

    private void AddListeners() {
        _placeObject.MarshallPlaced += OnMarshallPlaced;
        _signalsPanel.SignalSelected += OnSignalSelected;
    }

    private void OnSignalSelected(SignData data) => _marshall.ShowSignal(data);

    private void RemoveListeners() {
        _placeObject.MarshallPlaced -= OnMarshallPlaced;
        _signalsPanel.SignalSelected -= OnSignalSelected;
    }

    private void OnMarshallPlaced(Marshall marshall) {
        _marshall = marshall;

        _signalsPanel.gameObject.SetActive(true);
    }

    public void StartPlacing() {
        _placeObject.enabled = true;
    }

    public void Dispose() {
        RemoveListeners();
    }
}
