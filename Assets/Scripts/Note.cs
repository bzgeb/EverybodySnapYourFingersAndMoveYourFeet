using UnityEngine;

public enum NoteTarget {
    TopLeft,
    TopRight,
    MidLeft,
    MidRight,
    BottomLeft,
    BottomRight
}

[System.Serializable]
public class Note {
    public int timeInSamples;
    public NoteTarget target;
}