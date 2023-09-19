using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    List<sphereScript> spheres;
    // List<PLanescripts> planes;?????
    // Start is called before the first frame update
    void Start()
    {
        spheres = FindObjectsOfType<sphereScript>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spheres.Count-1; i++)
        {
            for (int j = i+1;  j < spheres.Count; j++)
            {
                if (spheres[i].isColliding( spheres[j]))
                {
                    spheres[j].velocity =
                        spheres[i].resolvedVolocityforCollisionWith(spheres[j]);
              

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
