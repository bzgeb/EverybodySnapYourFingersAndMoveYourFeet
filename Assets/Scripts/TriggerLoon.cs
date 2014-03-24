using UnityEngine;
using System.Collections;

public class TriggerLoon : MonoBehaviour 
{
    public string leftHandName;
    public string rightHandName;

    public GameObject leftHand;
    public GameObject rightHand;

    void Update() {
        if ( leftHand == null ) {
            leftHand = GameObject.Find( leftHandName );
        }

        if ( rightHand == null ) {
            rightHand = GameObject.Find( rightHandName );
        }

        if ( leftHand.transform.position.y > 6 && rightHand.transform.position.y > 6 ) {
            TriggerAudio();
        }
    }

    void TriggerAudio() {
        if ( audio.isPlaying ) {
            return;
        }

        audio.Play();
    }
}
