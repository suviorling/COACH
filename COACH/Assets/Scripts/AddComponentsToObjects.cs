using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// This is just script for adding necessary elements for gameObject
// so it could be interacted with.
// Not in use in 3D printing scene or Fueling scene
public class AddComponentsToObjects : MonoBehaviour
{
    public GameObject targetGameObject;


    public void AddComponents()
    {
        MeshCollider meshCollider = targetGameObject.AddComponent<MeshCollider>() as MeshCollider;
        Rigidbody rigidbody = targetGameObject.AddComponent<Rigidbody>() as Rigidbody;
        targetGameObject.GetComponent<Rigidbody>().isKinematic = true;
        XRGrabInteractable xrGrabInteractable = targetGameObject.AddComponent<XRGrabInteractable>() as XRGrabInteractable;
    }
}
