using UnityEngine;
using System.Collections;

public class RhythmTarget : MonoBehaviour 
{
    public Transform scaleTarget;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    public NoteTarget targetIdentity;

    public static Vector3 TopLeftTargetPosition;
    public static Vector3 TopRightTargetPosition;
    public static Vector3 MidLeftTargetPosition;
    public static Vector3 MidRightTargetPosition;
    public static Vector3 BottomLeftTargetPosition;
    public static Vector3 BottomRightTargetPosition;

    void Awake() {
        if ( targetIdentity == NoteTarget.TopLeft ) {
            TopLeftTargetPosition = transform.position;
        } else if ( targetIdentity == NoteTarget.TopRight ) {
            TopRightTargetPosition = transform.position;
        } else if ( targetIdentity == NoteTarget.MidLeft ) {
            MidLeftTargetPosition = transform.position;
        } else if ( targetIdentity == NoteTarget.MidRight ) {
            MidRightTargetPosition = transform.position;
        } else if ( targetIdentity == NoteTarget.BottomLeft ) {
            BottomLeftTargetPosition = transform.position;
        } else if ( targetIdentity == NoteTarget.BottomRight ) {
            BottomRightTargetPosition = transform.position;
        }
    }

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
    }
}
