using UnityEngine;
using System.Collections;

public class Arm : MonoBehaviour 
{
    public GameObject target;
    public string targetTag;

    Transform _transform;
    Transform targetTransform;

    Rigidbody rb;
    HingeJoint hinge;

    void Awake() {
        _transform = transform;
    }

    void Start() {
        rb = rigidbody;
        hinge = GetComponent<HingeJoint>();
    }

    void Update() {
        if ( target == null ) {
            target = GameObject.FindWithTag( targetTag );
        }

        if ( target != null && targetTransform == null ) {
            targetTransform = target.transform;
        }

        // if ( target != null && targetTransform != null ) {


            // _transform.rotation = Quaternion.LookRotation( forwardVector, Vector3.back ) * Quaternion.AngleAxis( 90, Vector3.back );
        // }
    }

    void FixedUpdate() {
        // if ( target != null && targetTransform != null ) {
        //     float angle = Vector3.Angle( targetTransform.position.normalized, _transform.position.normalized );
        //     // rb.AddTorque( 0, 0, -angle );
        //     // rb.

        //     Vector3 forwardVector = ( new Vector3( targetTransform.position.x, targetTransform.position.y, 0 ) - new Vector3( _transform.position.x, _transform.position.y, 0 ) ).normalized;
        //     // rb.rotation = Quaternion.AngleAxis( angle, Vector3.back );
        //     rb.rotation = Quaternion.LookRotation( Quaternion.AngleAxis( 90, Vector3.up ) * forwardVector, Vector3.back );
        // }
    }
}
