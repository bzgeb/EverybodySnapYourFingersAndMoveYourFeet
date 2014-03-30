using UnityEngine;
using System.Collections;

//In game representation of a note
public class Note : MonoBehaviour 
{
    //Cached transform
    Transform _transform;

    public AudioSource music;

    public NoteData noteData;
    Vector3 targetPosition;

    int xMultiplier;
    int yMultiplier;

    void Awake() {
        _transform = GetComponent<Transform>();
    }

    void Start() {
        music = GameObject.FindWithTag( "Music" ).GetComponent<AudioSource>();

        if ( noteData.target == NoteTarget.TopLeft ) {
            targetPosition = RhythmTarget.TopLeftTargetPosition;
            xMultiplier = -1;
            yMultiplier = 1;
        } else if ( noteData.target == NoteTarget.TopRight ) {
            targetPosition = RhythmTarget.TopRightTargetPosition;
            xMultiplier = 1;
            yMultiplier = 1;
        } else if ( noteData.target == NoteTarget.MidLeft ) {
            targetPosition = RhythmTarget.MidLeftTargetPosition;
            xMultiplier = -1;
            yMultiplier = 0;
        } else if ( noteData.target == NoteTarget.MidRight ) {
            targetPosition = RhythmTarget.MidRightTargetPosition;
            xMultiplier = 1;
            yMultiplier = 0;
        } else if ( noteData.target == NoteTarget.BottomLeft ) {
            targetPosition = RhythmTarget.BottomLeftTargetPosition;
            xMultiplier = -1;
            yMultiplier = -1;
        } else if ( noteData.target == NoteTarget.BottomRight ) {
            targetPosition = RhythmTarget.BottomRightTargetPosition;
            xMultiplier = 1;
            yMultiplier = -1;
        }

        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.material = Global.Get().noteMaterials[ (int)noteData.target ];
    }

    void Update() {
        int dist = music.timeSamples - noteData.timeInSamples;
        Vector3 newPos = Vector3.zero;

        newPos.y = targetPosition.y + dist * 0.00008f * yMultiplier;
        newPos.x = targetPosition.x + dist * 0.00008f * xMultiplier;

        _transform.position = newPos;
    }
}
