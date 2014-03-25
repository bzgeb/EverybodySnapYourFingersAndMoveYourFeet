using UnityEngine;
using UnityEditor;

public class CreateNoteData : MonoBehaviour {
    [MenuItem("Assets/Create/NoteData")]
    public static void CreateAsset() {
       ScriptableObjectUtility.CreateAsset<NoteData> (); 
    }
}
