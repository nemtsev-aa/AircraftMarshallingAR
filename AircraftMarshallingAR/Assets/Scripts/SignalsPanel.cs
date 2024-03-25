using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ToggleGroup))]
public class SignalsPanel : MonoBehaviour, IDisposable {
    public event Action<SignData> SignalSelected;

    [SerializeField] private SignalView _signalViewPrefab;
    [SerializeField] private RectTransform _signalViewParent;

    private ToggleGroup _group;
    private List<SignalView> _views = new List<SignalView>();
    private SignDataConfig _config;

    private void Awake() {
        _group ??= GetComponent<ToggleGroup>();
    }

    public void Init(SignDataConfig config) {
        _config = config;

        CreateSignalViews();
        AddListeners();
    }

    private void CreateSignalViews() {
        foreach (var iSignal in _config.Signs) {
            CreateSignalView(iSignal);
        }
    }

    private void CreateSignalView(SignData signal) {
        SignalView view = Instantiate(_signalViewPrefab, _signalViewParent);
        view.Init(signal, _group);

        _views.Add(view);
    }

    private void AddListeners() {
        if (_views.Count == 0)
            return;

        foreach (var iView in _views) {
            iView.Selected += OnSignalViewSelected;
        }
    }

    private void RemoveListeners() {
        if (_views.Count == 0)
            return;

        foreach (var iView in _views) {
            iView.Selected -= OnSignalViewSelected;
        }
    }

    private void OnSignalViewSelected(int index) => SignalSelected?.Invoke(GetSignDataByIndex(index));

    private SignData GetSignDataByIndex(int index) {
        return _config.Signs.First(signal => signal.Index == index);
    }

    public void Dispose() {
        RemoveListeners();
    }
}