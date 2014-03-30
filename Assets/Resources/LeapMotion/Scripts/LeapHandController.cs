using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Leap;

public class LeapHandController : MonoBehaviour {

    [SerializeField]
    Transform m_parent;

    [SerializeField]
    Vector3 m_offset;

    Controller m_leapController;

    public GameObject leftHand;
    public GameObject rightHand;

    Transform leftHandTransform;
    Transform rightHandTransform;

    void Start () {
        m_leapController = new Controller();

        leftHandTransform = leftHand.transform;
        rightHandTransform = rightHand.transform;
    }

    void Update () {
        Frame f = m_leapController.Frame();

        // see what hands the leap sees and mark matching hands as not stale.
        for(int i = 0; i < f.Hands.Count; ++i) {
            Vector3 handPosition = f.Hands[i].PalmPosition.ToUnityScaled() + m_offset;
            if ( f.Hands[i].IsRight ) {
                rightHandTransform.position = handPosition;
                HandTracker.rightHandPosition = handPosition;
            } else {
                leftHandTransform.position = handPosition;
                HandTracker.leftHandPosition = handPosition;
            }
        }
    }
}
