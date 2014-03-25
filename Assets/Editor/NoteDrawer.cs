using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(NoteData))]
public class NoteDrawer : PropertyDrawer 
{
    public override void OnGUI( Rect position, SerializedProperty property, GUIContent label ) {
        EditorGUI.BeginProperty( position, label, property );

        position = EditorGUI.PrefixLabel( position, GUIUtility.GetControlID( FocusType.Passive ), label );

        var timeInSamplesRect = new Rect( position.x - 60, position.y, 80, position.height );
        var targetRect = new Rect( position.x + 35, position.y, 95, position.height );

        EditorGUI.PropertyField( timeInSamplesRect, property.FindPropertyRelative( "timeInSamples" ), GUIContent.none );
        EditorGUI.PropertyField( targetRect, property.FindPropertyRelative( "target" ), GUIContent.none );

        EditorGUI.EndProperty();
    }
}
