using UnityEngine;
using System.Collections;

public class HandTracker : MonoBehaviour 
{
    public string leftHandName;
    public string rightHandName;

    public static GameObject leftHand;
    public static GameObject rightHand;

    public static Vector3 leftHandPosition;
    public static Vector3 rightHandPosition;

    public static Transform leftHandTransform;
    public static Transform rightHandTransform;

    void Update() {
        if ( leftHand == null ) {
            leftHand = GameObject.Find( leftHandName );
            leftHandTransform = leftHand.transform;
        } else {
            leftHandPosition = leftHandTransform.position;
        }

        if ( rightHand == null ) {
            rightHand = GameObject.Find( rightHandName );
            rightHandTransform = rightHand.transform;
        } else {
            rightHandPosition = rightHandTransform.position;
        }
    }
}
