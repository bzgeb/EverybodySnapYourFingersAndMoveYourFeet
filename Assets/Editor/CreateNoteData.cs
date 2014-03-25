using UnityEngine;
using UnityEditor;

public class CreateNoteData : MonoBehaviour {
    [MenuItem("Assets/Create/SongData")]
    public static void CreateAsset() {
       ScriptableObjectUtility.CreateAsset<SongData> (); 
    }
}
