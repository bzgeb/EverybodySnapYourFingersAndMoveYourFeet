using UnityEngine;
using System.Collections;

public class RightWrist : MonoBehaviour 
{
    Transform _transform;

    void Awake() {
        _transform = transform;
    }

    void Update() {
        HandTracker.rightHandPosition = _transform.position;
    }
}
