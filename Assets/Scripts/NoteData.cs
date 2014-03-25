using UnityEngine;

// Data for a given note associated with a song
public enum NoteTarget {
    TopLeft,
    TopRight,
    MidLeft,
    MidRight,
    BottomLeft,
    BottomRight
}

[System.Serializable]
public class NoteData {
    public int timeInSamples;
    public NoteTarget target;
}