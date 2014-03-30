using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour 
{
    public int timeInSamples;

    public KeyCode playButton;
    public KeyCode jumpBackButton;
    public KeyCode jumpForwardButton;
    public KeyCode reloadSongButton;
    public KeyCode createNoteButton;

    public SongData songData;

    public GameObject[] notes;

    public Object notePrefab;

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

        if ( Input.GetKeyDown( jumpForwardButton ) ) {
            audio.Pause();

            timeInSamples = audio.timeSamples;
            timeInSamples += audio.clip.frequency * 5;

            audio.timeSamples = timeInSamples;

            audio.Play();
        }

        if ( Input.GetKeyDown( reloadSongButton ) ) {
            Reload();
        }

        if ( Input.GetKeyDown( createNoteButton ) ) {
            InstantiateNewNote();
        }
    }

    void Reload() {
        foreach ( GameObject go in notes ) {
            Destroy( go );
        }

        foreach ( NoteData noteData in songData.notes ) {
            GameObject newNote = Instantiate( notePrefab ) as GameObject;
            Note n = newNote.GetComponent<Note>();
            n.noteData = noteData;
        }
    }

    void InstantiateNewNote() {
        GameObject newNote = Instantiate( notePrefab ) as GameObject;
        Note n = newNote.GetComponent<Note>();
        n.noteData.timeInSamples = audio.timeSamples;
        songData.notes.Add( n.noteData );
    }
}
