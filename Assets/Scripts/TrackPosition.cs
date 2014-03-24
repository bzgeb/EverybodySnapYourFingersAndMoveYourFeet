using UnityEngine;
using System.Collections;

public class TrackPosition : MonoBehaviour 
{
    public string trackObjectName;
    public GameObject hand;

    public Vector2 pitchFrom;
    public Vector2 pitchTo;

    public Vector2 volumeFrom;
    public Vector2 volumeTo;

    void Update() {
        if ( hand == null ) {
            hand = GameObject.Find( trackObjectName );
        }
        audio.pitch = Mathf.Clamp( hand.transform.position.y.Remap( /*-1, 7, -2, 2*/ pitchFrom.x, pitchFrom.y, pitchTo.x, pitchTo.y ), pitchTo.x, pitchTo.y );

        audio.volume = Mathf.Clamp( hand.transform.position.z.Remap( /*-1, 1, 0.3f, 1*/ volumeFrom.x, volumeFrom.y, volumeTo.x, volumeTo.y ), volumeTo.x, volumeTo.y );
    }
}
