using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sphereScript : MonoBehaviour
{
    public sphereScript otherSphere;

    public float assignRadius;

    Vector3 acceleration;
    [SerializeField]
    internal Vector3 velocity;
    private float mass = 1;

    public float Radius
    { get { return transform.localScale.x/2.0f; } 
      private set { transform.localScale = 2* value * Vector3.one; } }

    internal bool isColliding(sphereScript otherSphere)
    {
       float distance = Vector3.Distance(transform.position,
            otherSphere.transform.position);

        return distance < Radius + otherSphere.Radius;
      
    }

    // Start is called before the first frame update
    void Start()
    {   
        acceleration = 9.8f * Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        Radius = assignRadius;

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;


    }

    internal Vector3 resolvedVolocityforCollisionWith(sphereScript otherSphere)
    {
        Vector3 normal = transform.position - otherSphere.transform.position;
        Vector3 u1 = parallel(velocity, normal);
        Vector3 u2 = parallel(otherSphere.velocity, normal);
        Vector3 s1 = perpendicular(velocity, normal);
        Vector3 s2 = perpendicular(otherSphere.velocity, normal);

        float m1 = mass;
        float m2 = otherSphere.mass;

        Vector3 v1 = ((m1 - m2) / (m1 + m2)) * u1 + (2 * m2 / (m1 + m2)) * u2;

        Vector3 v2 =  (2 * m1 / (m1 + m2)) * u1  + ((m2 - m1) / (m1 + m2)) * u2;

        velocity = v1 + s1;
        return v2 + s2;



    }
    
    private Vector3 perpendicular(Vector3 velocity, Vector3 normal)
    {
        throw new NotImplementedException();
    }

    private Vector3 parallel(Vector3 velocity, Vector3 normal)
    {
        throw new NotImplementedException();
    }
}
