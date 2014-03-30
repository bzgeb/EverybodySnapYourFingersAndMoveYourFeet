using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour 
{
    public int timeInSamples;

    public KeyCode playButton;
    public KeyCode jumpBackButton;

    void Update() {
        if ( Input.GetKeyDown( playButton ) ) {

            if ( audio.isPlaying ) {
                timeInSamples = audio.timeSamples;
                audio.Pause();
            } else {
                audio.timeSamples = timeInSamples;
                audio.Play();
            }

        }

        if ( Input.GetKeyDown( jumpBackButton ) ) {
            audio.Pause();

            timeInSamples = audio.timeSamples;
            timeInSamples -= audio.clip.frequency * 5;

            audio.timeSamples = timeInSamples;

            audio.Play();
        }
    }
}
