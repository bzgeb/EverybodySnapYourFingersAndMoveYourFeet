using UnityEngine;
using System.Collections;

public class Leg : MonoBehaviour 
{
    Rigidbody rb;

    void Start() {
        rb = rigidbody;
    }

    void FixedUpdate() {
        var target = rb.rotation.z;

        rb.AddTorque( 0, 0, 1 * -target * 100 );
    }
}
