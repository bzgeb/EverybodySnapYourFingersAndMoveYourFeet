using UnityEngine;
using System.Collections;
using Leap;

public class UnityHand : MonoBehaviour {

    public bool m_stale = false;

    Hand m_rawHand;
    GameObject [] m_fingers = new GameObject[5];
    GameObject m_meshHand;
    GameObject m_rigBones;

    Vector3 m_offset;
    Transform m_parent;

    float m_distancePalmToWrist = 0.8f;
    float m_handScaleFactor = 1.0f;
    float m_leapExtensionScale = 1500.0f;

    public void Initialize(Hand h, Transform parent, Vector3 offset) {
        m_rawHand = h;
        if (h.IsRight) {
            m_meshHand = Instantiate(Resources.Load("LeapMotion/Prefabs/RightHandMesh")) as GameObject;
        } else {
            m_meshHand = Instantiate(Resources.Load("LeapMotion/Prefabs/LeftHandMesh")) as GameObject;
        }
        m_rigBones = m_meshHand.transform.Find("Mesh").gameObject;
        m_parent = parent;
        m_offset = offset;
    }

    public void UpdateHand(Hand h) {
        m_rawHand = h;
        transform.position = m_parent.TransformPoint(h.PalmPosition.ToUnityScaled());
        UpdateMesh();
        UpdatePhysics();
    }

    public Hand GetLeapHand() {
        return m_rawHand;
    }

    public GameObject [] GetFingers() {
        return m_fingers;
    }

    public void EnableMesh(bool enable) {
        m_rigBones.GetComponent<SkinnedMeshRenderer>().enabled = enable;
    }

    public void EnablePhysics(bool enable) {

    }

    public SkinnedMeshRenderer GetMesh() {
        return m_rigBones.GetComponent<SkinnedMeshRenderer>();
    }

    void UpdateMesh() {
        if (m_meshHand == null) Debug.LogError("Rigged Hand is null, did you call InitializeHand?");
        // get the bones from the rig
        Transform [] boneTransforms = m_rigBones.GetComponent<SkinnedMeshRenderer>().bones;

        if (m_rawHand.IsRight) {
            UpdateHandRig(boneTransforms);
        } else {
            UpdateHandRig(boneTransforms);
        }
        m_stale = false;
        float scale = WristToMiddleKnuckle() / 55.0f;
        scale *= m_leapExtensionScale * UnityVectorExtension.InputScale.x;
        m_meshHand.transform.localScale = new Vector3(scale, scale, scale);
    }

    Transform FindBone(Transform [] array, string boneName) {
        for (int i = 0; i < array.Length; ++i) {
            if (array[i].name == boneName) return array[i];
        }
        Debug.LogError("Bone Not Found: " + boneName);
        return null;
    }

    void UpdateHandRig(Transform [] bones) {

        Transform armTransform = FindBone(bones, "Wrist");
        armTransform.position = m_rawHand.PalmPosition.ToUnityScaled();
        
        armTransform.rotation = Quaternion.LookRotation(m_rawHand.Direction.ToUnity(), -m_rawHand.PalmNormal.ToUnity());

        for (int i = 0; i < m_rawHand.Fingers.Count; ++i) {
            Finger finger = m_rawHand.Fingers[i];
            
            // get all the joint positions in unity space.
            Vector3 mcpPos = finger.JointPosition(Finger.FingerJoint.JOINT_MCP).ToUnityScaled();
            Vector3 pipPos = finger.JointPosition(Finger.FingerJoint.JOINT_PIP).ToUnityScaled();
            Vector3 dipPos = finger.JointPosition(Finger.FingerJoint.JOINT_DIP).ToUnityScaled();
            Vector3 tipPos = finger.JointPosition(Finger.FingerJoint.JOINT_TIP).ToUnityScaled();
            
            // compute finger joint rotations
            Transform mcp = FindBone(bones, "Finger_" + i + "0");
            mcp.rotation = Quaternion.FromToRotation(m_rawHand.Direction.ToUnity(), (pipPos - mcpPos).normalized);
            
            mcp.rotation *= armTransform.rotation;
            
            Transform pip = FindBone(bones, "Finger_" + i + "1");
            pip.rotation = Quaternion.FromToRotation((pipPos - mcpPos).normalized, (dipPos - pipPos).normalized) * mcp.rotation;
            Transform dip = FindBone(bones, "Finger_" + i + "2");
            dip.rotation = Quaternion.FromToRotation((dipPos - pipPos).normalized, (tipPos - dipPos).normalized) * pip.rotation;
        }
    }

    float WristToMiddleKnuckle() {
        return m_rawHand.Fingers[2].Length;
    }

    void UpdatePhysics() {
        for (int i = 0; i < m_fingers.Length; ++i) {
            UnityFinger finger = m_fingers[i].GetComponent<UnityFinger>();
            GameObject [] joints = finger.GetJoints();
            GameObject [] bones = finger.GetBones();
            for(int j = 0; j < joints.Length; ++j) {
                Vector3 pos = m_parent.TransformPoint(m_offset + m_rawHand.Fingers[i].JointPosition((Finger.FingerJoint) j).ToUnityScaled());
                Vector3 nextPos = m_parent.TransformPoint(m_offset + m_rawHand.Fingers[i].JointPosition((Finger.FingerJoint) j + 1).ToUnityScaled());
                joints[j].transform.position = pos;
                joints[j].rigidbody.velocity = m_parent.TransformDirection(m_rawHand.Fingers[i].TipVelocity.ToUnityScaled());

                if (j < bones.Length) {
                    Vector3 langePos = (pos + nextPos) * 0.5f;
                    bones[j].transform.position = langePos;
                    bones[j].transform.up = (nextPos - pos);
                    Vector3 newScale = bones[j].transform.localScale;
                    newScale.y = Mathf.Max(0.0f, (nextPos - pos).magnitude - 0.003f);
                    bones[j].transform.localScale = newScale;
                }
            }
        }
    }

    // Use this for initialization
    void Awake() {
        for (int i = 0; i < m_fingers.Length; ++i) {
            m_fingers[i] = Instantiate(Resources.Load("LeapMotion/Prefabs/UnityFinger")) as GameObject;
        }
    }

    void OnDestroy() {
        Destroy(m_meshHand);
        for (int i = 0; i < m_fingers.Length; ++i) {
            Destroy(m_fingers[i]);
        }
    }
}
