using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Transform holdPoint;
    public float pickUpRadius = 1.5f;

    private GameObject heldObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
                TryPickUp();
            else
                DropObject();
        }
    }

    void TryPickUp()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, pickUpRadius);

        foreach (Collider col in hits)
        {
            if (col.CompareTag("PickUp"))
            {
                heldObject = col.gameObject;

                heldObject.transform.SetParent(holdPoint);
                heldObject.transform.localPosition = Vector3.zero;
                heldObject.transform.localRotation = Quaternion.identity;

                Rigidbody rb = heldObject.GetComponent<Rigidbody>();
                rb.isKinematic = true;

                return;
            }
        }
    }

    void DropObject()
    {
        heldObject.transform.SetParent(null);

        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        heldObject = null;
    }
}