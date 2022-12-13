using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    private float rotz;
    public float rotationSpeed;
    public bool clockwiseRotation;



    // Update is called once per frame
    void Update()
    {
        if (clockwiseRotation == false)
            rotz += Time.deltaTime * rotationSpeed;
        else
            rotz += -Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotz);

    }   
}
