using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour 
{
    public static Vector3 noteCenterPosition = new Vector3( 0, 3.5f, 0 );
    public Material[] noteMaterials;

    public static Global instance;

    void Awake() {
        instance = this;
    }

    public static Global Get() {
        return instance;
    }
}
