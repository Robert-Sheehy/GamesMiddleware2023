using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    List<sphereScript> spheres;

    //List<IPhysical> allObjects;
    
    // List<PLanescripts> planes;?????
    // Start is called before the first frame update
    void Start()
    {
        spheres = FindObjectsOfType<sphereScript>().ToList();
        allObjects = FindObjectsOfType<IPhysical>().ToList();  // Note we wish to find all IMPLEMENTATIONS of this interface
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < allObjects.Count-1; i++)
        {
            for (int j = i+1;  j < allObjects.Count; j++)
            {
                if (allObjects[i].isColliding( allObjects[j]))
                {
                    allObjects[j].velocity =
                        allObjects[i].resolvedVolocityforCollisionWith(allObjects[j]);
                 // (Vector3 , Vector3) (position, velocity) = 
                //  allObjects[i].resolvedVolocityforCollisionWith(allObjects[j]);

                }
            }

    
        for (int i = 0; i < spheres.Count-1; i++)
        {
            for (int j = i+1;  j < spheres.Count; j++)
            {
                if (spheres[i].isColliding( spheres[j]))
                {
                    spheres[j].velocity =
                        spheres[i].resolvedVolocityforCollisionWith(spheres[j]);
                 // (Vector3 , Vector3) (position, velocity) = 
                //  spheres[i].resolvedVolocityforCollisionWith(spheres[j]);

                }
            }
        }
    }

    private bool isColliding(sphereScript sphereScript1, sphereScript sphereScript2)
    {
        return Vector3.Distance(sphereScript1.transform.position,
                                sphereScript2.transform.position) < 
                                sphereScript1.Radius + sphereScript2.Radius;
    }
}
