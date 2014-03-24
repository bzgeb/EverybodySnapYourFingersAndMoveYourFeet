using UnityEngine;
using System.Collections;

public class ScaleBasedOnPitch : MonoBehaviour 
{
    public AudioSource source;
    public TrackPosition tracker;

    void Update() {
        float scaleValue = source.pitch.Remap( tracker.pitchTo.x, tracker.pitchTo.y, 1, 5 );

        transform.localScale = new Vector3( scaleValue, scaleValue, scaleValue );
    }
}
