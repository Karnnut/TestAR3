using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowBoxCollider : MonoBehaviour
{
    public Vector3 mainColliderSize = new Vector3(2f, 2f, 2f);
    public Vector3 hollowColliderSize = new Vector3(1f, 1f, 1f);

    void Start()
    {
        // Create the main GameObject with a Box Collider
        GameObject hollowBoxObject = new GameObject("HollowBoxObject");
        hollowBoxObject.AddComponent<BoxCollider>();
        hollowBoxObject.transform.position = Vector3.zero;

        // Create child GameObjects for the hollow areas with Box Colliders
        GameObject hollowArea1 = new GameObject("HollowArea1");
        hollowArea1.AddComponent<BoxCollider>();
        hollowArea1.transform.parent = hollowBoxObject.transform;
        hollowArea1.transform.localPosition = Vector3.zero; // Adjust position
        hollowArea1.transform.localScale = hollowColliderSize; // Adjust size

        GameObject hollowArea2 = new GameObject("HollowArea2");
        hollowArea2.AddComponent<BoxCollider>();
        hollowArea2.transform.parent = hollowBoxObject.transform;
        hollowArea2.transform.localPosition = new Vector3(0f, 0f, -1.5f); // Adjust position
        hollowArea2.transform.localScale = hollowColliderSize; // Adjust size
    }
}
