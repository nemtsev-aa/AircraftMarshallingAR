using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
using System;

[RequireComponent(typeof(ARRaycastManager), typeof(ARPlaneManager))]
public class PlaceObject : MonoBehaviour {
    public event Action<Marshall> MarshallPlaced;

    [SerializeField] private Marshall _prefab;

    private ARRaycastManager _arRaycastManager;
    private ARPlaneManager _arPlaneManager;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private Marshall _marshall;

    private void Awake() {
        _arRaycastManager ??= GetComponent<ARRaycastManager>();
        _arPlaneManager ??= GetComponent<ARPlaneManager>();
    }

    public void Reset() {
        _arPlaneManager.enabled = true;
        _hits.Clear();
        ShowAllPlanes(false);
    }

    private void OnEnable() {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable() {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void FingerDown(Finger finger) {
        if (finger.index != 0) return;

        if (_marshall != null) return;


        if (_arRaycastManager.Raycast(finger.currentTouch.screenPosition, _hits, TrackableType.PlaneWithinPolygon)) {
            foreach (var hit in _hits) {
                Pose pose = hit.pose;
                _marshall = Instantiate(_prefab, pose.position, pose.rotation);

                if (_arPlaneManager.GetPlane(hit.trackableId).alignment == PlaneAlignment.HorizontalUp) {
                    RotationFriendToCamera();

                    ShowAllPlanes(false);

                    MarshallPlaced?.Invoke(_marshall);
                }
            }
        }
    }

    private void RotationFriendToCamera() {
        Vector3 position = _marshall.transform.position;
        position.y = 0f;

        Vector3 cameraPosition = Camera.main.transform.position;
        cameraPosition.y = 0f;

        Vector3 direction = cameraPosition - position;
        Vector3 targetRotationEuler = Quaternion.LookRotation(direction).eulerAngles;
        Vector3 scaledEuler = Vector3.Scale(targetRotationEuler, _marshall.transform.up.normalized);
        Quaternion targetRotation = Quaternion.Euler(scaledEuler);

        _marshall.transform.rotation *= targetRotation;
    }

    private void ShowAllPlanes(bool status) {
        foreach (var plane in _arPlaneManager.trackables) {
            plane.gameObject.SetActive(status);
        }

        _arPlaneManager.enabled = false;
    }
}
