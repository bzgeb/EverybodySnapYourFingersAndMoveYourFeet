using UnityEngine;
using System.Collections;

public class ScaleBasedOnVolume : MonoBehaviour 
{
    public AudioSource source;
    public TrackPosition tracker;

    void Update() {
        float scaleValue = source.volume.Remap( tracker.volumeTo.x, tracker.volumeTo.y, 1, 5 );

        transform.localScale = new Vector3( scaleValue, scaleValue, scaleValue );
    }
}
