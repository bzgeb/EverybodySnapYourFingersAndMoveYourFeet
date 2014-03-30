using UnityEngine;
using System.Collections;

public class LeftWrist : MonoBehaviour 
{
    Transform _transform;

    void Awake() {
        _transform = transform;
    }

    void Update() {
        HandTracker.leftHandPosition = _transform.position;
    }
}
