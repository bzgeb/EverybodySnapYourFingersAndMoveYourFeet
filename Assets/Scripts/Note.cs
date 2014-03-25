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
        Debug.Log( "Samples: " + music.timeSamples );
        _transform.position = RhythmTarget.TopLeftTargetPosition - ( new Vector3( 0.0001f, 0.0001f, 0.0001f ) * ( music.timeSamples - strumTime ) );
    }
}
