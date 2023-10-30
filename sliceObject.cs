using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EzySlice;

public class sliceObject : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public Material crossMaterial;
    public float cutForce = 2000;
    public LayerMask sliceLayer;
    public VelocityEstimator velocity_e;
    public AudioSource sliceSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceLayer);
        if(hasHit)
        {
            GameObject target = hit.transform.gameObject;
            slice(target);
            
        }
    }
    public void slice(GameObject target)
    {
        Vector3 velocity = velocity_e.GetVelocityEstimate();
        Vector3 plane = Vector3.Cross(endSlicePoint.position-startSlicePoint.position,velocity);
        plane.Normalize();

        SlicedHull hull = target.Slice(endSlicePoint.position, plane);
        sliceSound.Play();
        if (hull !=null)
        {
           
            GameObject upper = hull.CreateUpperHull(target, crossMaterial);
            SlicedObjectPart(upper);
            GameObject lower = hull.CreateLowerHull(target, crossMaterial);
            SlicedObjectPart(lower);
            Destroy(target);
         
        }
    }
    public void  SlicedObjectPart (GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        rb.AddExplosionForce(cutForce, slicedObject.transform.position,1);
    }
}
