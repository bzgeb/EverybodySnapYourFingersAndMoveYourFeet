using UnityEngine;
using System.Collections;

public class RhythmTarget : MonoBehaviour 
{
    public MicControlC micControl;
    public Transform scaleTarget;

    public Vector2 minPosition;
    public Vector2 maxPosition;


    void Update() {
        CheckHandPosition( HandTracker.leftHandPosition );
        CheckHandPosition( HandTracker.rightHandPosition );
    }

    void CheckHandPosition( Vector3 pos ) {
        if ( pos.x > minPosition.x && pos.x < maxPosition.x ) {
            if ( pos.y > minPosition.y && pos.y < maxPosition.y ) {
                DoScale();
            }
        }
    }

    void DoScale() {
        float scale = Mathf.Sin( Time.timeSinceLevelLoad ).Remap( -1, 1, 0.5f, 2 );
        scaleTarget.localScale = new Vector3( scale, scale, scale );

        if ( micControl.loudness > 1.0f ) {
            scaleTarget.localScale = new Vector3( 2.5f, 2.5f, 2.5f );
        }
    }
}
