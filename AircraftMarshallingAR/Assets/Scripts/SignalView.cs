using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignalView : MonoBehaviour, IDisposable {
    public event Action<int> Selected;

    [SerializeField] private Toggle _signalToggle;
    [SerializeField] private TextMeshProUGUI _nameLabel;
    [SerializeField] private Image _icon;

    private SignData _data;

    public void Init(SignData data, ToggleGroup group) {
        _data = data;

        FillingCompanents(group);
        AddListeners();
    }

    private void FillingCompanents(ToggleGroup group) {
        _signalToggle.group = group;

        _nameLabel.text = _data.Name;
        _icon.sprite = _data.Icon;
    }

    private void AddListeners() {
        _signalToggle.onValueChanged.AddListener(SignalButtonClick);
    }

    private void RemoveListeners() {
        _signalToggle.onValueChanged.AddListener(SignalButtonClick);
    }

    private void SignalButtonClick(bool value) {
        
        if (value)
            Selected?.Invoke(_data.Index);
    }

    public void Dispose() => RemoveListeners();
}