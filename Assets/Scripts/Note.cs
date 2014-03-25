using UnityEngine;
using System.Collections;

//In game representation of a note
public class Note : MonoBehaviour 
{
    //Cached transform
    Transform _transform;

    public AudioSource music;
    public int strumTime;

    void Awake() {
        _transform = GetComponent<Transform>();
    }

    void Start() {
        music = GameObject.FindWithTag( "Music" ).GetComponent<AudioSource>();
    }

    void Update() {
        Vector3 newPos = Vector3.zero;
        newPos.y = RhythmTarget.TopLeftTargetPosition.y + ( music.timeSamples - strumTime ) * 0.00008f;
        newPos.x = RhythmTarget.TopLeftTargetPosition.x - ( music.timeSamples - strumTime ) * 0.00008f;
        _transform.position = newPos;
        // _transform.position = Global.noteCenterPosition + ( RhythmTarget.TopLeftTargetPosition - Global.noteCenterPosition ) * ( (float)music.timeSamples / (float)strumTime );
    }
}
